using UnityEngine;
using Unity.Barracuda;
using Vuforia;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using Image = Vuforia.Image;

public class EnhancedClassification : MonoBehaviour
{
    const PixelFormat PIXEL_FORMAT = PixelFormat.RGB888;
    const TextureFormat TEXTURE_FORMAT = TextureFormat.RGB24;
    const int IMAGE_SIZE = 224;

    [Header("Model Settings")]
    public NNModel modelAsset;
    public TextAsset labelAsset;

    public Text text;

    [Header("UI Settings")]
    public RawImage cameraPreview;
    public Text resultText;
    public Text probText;

    private Model runtimeModel;
    private IWorker worker;
    private string[] labels;
    private Texture2D mTexture;
    private bool mFormatRegistered;
    private float lastInferenceTime;

    public Button btnInferrence;

    //
    private List<string> targetLabels = new List<string> { "原料区", "混料区", "挤出区", "干燥区", "烧成区", "切割区", "包装区", "仓储区" };

    private string currentTarget;
    void Start()
    {
        // 初始化模型和标签
        runtimeModel = ModelLoader.Load(modelAsset);
        worker = WorkerFactory.CreateWorker(WorkerFactory.Type.ComputePrecompiled, runtimeModel);
        ParseLabels();

        btnInferrence.onClick.AddListener(PerformInference);

        // 初始化Vuforia回调
        VuforiaApplication.Instance.OnVuforiaStarted += OnVuforiaStarted;
        VuforiaApplication.Instance.OnVuforiaStopped += OnVuforiaStopped;
        if (VuforiaBehaviour.Instance != null)
            VuforiaBehaviour.Instance.World.OnStateUpdated += OnVuforiaUpdated;
    }


    void ParseLabels()
    {
        var stringArray = labelAsset.text.Split('"').Where((item, index) => index % 2 != 0);
        labels = stringArray.Where((x, i) => i % 2 != 0).ToArray();
    }

    void OnVuforiaStarted()
    {
        mTexture = new Texture2D(0, 0, TEXTURE_FORMAT, false);
        RegisterFormat();
    }

    void OnVuforiaStopped()
    {
        UnregisterFormat();
        if (mTexture != null)
            Destroy(mTexture);
    }

    void OnVuforiaUpdated()
    {
        var image = VuforiaBehaviour.Instance.CameraDevice.GetCameraImage(PIXEL_FORMAT);
        if (Image.IsNullOrEmpty(image)) return;

        // 更新预览纹理
        image.CopyToTexture(mTexture, true);
        ////cameraPreview.texture = mTexture;

        //// 控制推理频率（每秒约5次）
        //if (Time.time - lastInferenceTime < 0.2f) return;

        //// 准备输入数据
        //Tensor input = PreprocessTexture(mTexture);

        //// 执行推理
        //worker.Execute(input);
        //Tensor output = worker.CopyOutput();

        //// 解析结果
        //var probabilities = output.ToReadOnlyArray();
        //UpdateUI(probabilities);

        //// 释放资源
        //input.Dispose();
        //output.Dispose();
        //lastInferenceTime = Time.time;
    }

    //新增的推理函数
    private void PerformInference()
    {
        if (mTexture == null)
            return;

        // 准备输入数据
        Tensor input = PreprocessTexture(mTexture);

        // 执行推理
        worker.Execute(input);
        Tensor output = worker.CopyOutput();

        // 解析结果
        var probabilities = output.ToReadOnlyArray();
        UpdateUI(probabilities);

        // 释放资源
        input.Dispose();
        output.Dispose();
    }

    Tensor PreprocessTexture(Texture2D source)
    {
        // 调整尺寸并预处理
        var scaled = ScaleTexture(source, IMAGE_SIZE, IMAGE_SIZE);
        byte[] pixels = scaled.GetRawTextureData();
        float[] transformed = new float[pixels.Length];

        for (int i = 0; i < pixels.Length; i++)
        {
            transformed[i] = (pixels[i] - 127f) / 128f; // 标准化
        }

        Destroy(scaled);
        return new Tensor(1, IMAGE_SIZE, IMAGE_SIZE, 3, transformed);
    }

    Texture2D ScaleTexture(Texture2D source, int width, int height)
    {
        // 使用双线性缩放
        RenderTexture rt = RenderTexture.GetTemporary(width, height);
        Graphics.Blit(source, rt);
        RenderTexture previous = RenderTexture.active;
        RenderTexture.active = rt;

        Texture2D result = new Texture2D(width, height, TEXTURE_FORMAT, false);
        result.ReadPixels(new Rect(0, 0, width, height), 0, 0);
        result.Apply();

        RenderTexture.active = previous;
        RenderTexture.ReleaseTemporary(rt);
        return result;
    }

    void UpdateUI(float[] probabilities)
    {
        int maxIndex = GetMaxIndex(probabilities);
        resultText.text = $"识别结果: {labels[maxIndex]}";

        string currentLabel = labels[maxIndex];

        probText.text = "概率分布:\n";
        for (int i = 0; i < Mathf.Min(5, probabilities.Length); i++) // 只显示前5个
        {
            probText.text += $"{labels[i]}: {probabilities[i]:F2}\n";
        }

        CheckTargetRecognotion(currentLabel);
    }

    private void CheckTargetRecognotion(string currentLabel)
    {
        bool isTarget = targetLabels.Contains(currentLabel);

        if (isTarget)
        {
            if (currentTarget != currentLabel)
            {
                currentTarget = currentLabel;
                ShowTargetUI(currentTarget);
            }
        }
    }

    private void ShowTargetUI(string labelName)
    {
        //UIMgr.Instance.GetPanel<AIPanel>().TargetUI.SetActive(true);
        //UIMgr.Instance.GetPanel<AIPanel>().labelName.text = labelName;
    }

    int GetMaxIndex(float[] data) => data.ToList().IndexOf(data.Max());

    void RegisterFormat()
    {
        mFormatRegistered = VuforiaBehaviour.Instance.CameraDevice.SetFrameFormat(PIXEL_FORMAT, true);
        Debug.Log(mFormatRegistered ? $"成功注册{PIXEL_FORMAT}" : "格式注册失败");
    }

    void UnregisterFormat()
    {
        VuforiaBehaviour.Instance.CameraDevice.SetFrameFormat(PIXEL_FORMAT, false);
        mFormatRegistered = false;
    }

    void OnDestroy()
    {
        worker?.Dispose();
        if (VuforiaBehaviour.Instance != null)
            VuforiaBehaviour.Instance.World.OnStateUpdated -= OnVuforiaUpdated;

        VuforiaApplication.Instance.OnVuforiaStarted -= OnVuforiaStarted;
        VuforiaApplication.Instance.OnVuforiaStopped -= OnVuforiaStopped;

        if (mTexture != null)
            Destroy(mTexture);
    }
}