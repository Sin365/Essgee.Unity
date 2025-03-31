using System;
using UnityEngine;
using UnityEngine.UI;

public class UEGVideoPlayer : MonoBehaviour
{
    [SerializeField]
    private int mWidth;
    [SerializeField]
    private int mHeight;
    [SerializeField]
    private int mDataLenght;
    [SerializeField]
    private Texture2D m_rawBufferWarper;
    [SerializeField]
    private RawImage m_drawCanvas;
    [SerializeField]
    private RectTransform m_drawCanvasrect;
    //byte[] mFrameData;
    IntPtr mFrameDataPtr;

    private TimeSpan lastElapsed;
    public double videoFPS { get; private set; }
    public ulong mFrame { get; private set; }
    bool bInit = false;
    bool bHadData = false;

    private void Awake()
    {
        mFrame = 0;
        m_drawCanvas = GameObject.Find("GameRawImage").GetComponent<RawImage>();
        m_drawCanvasrect = m_drawCanvas.GetComponent<RectTransform>();
    }

    public void Initialize()
    {
        m_drawCanvas.color = Color.white;

        if (m_rawBufferWarper == null)
        {
            mDataLenght = mWidth * mHeight * 4;
            //mFrameData = new byte[mDataLenght];

            //// �̶����飬��ֹ�����������ƶ���  
            //var bitmapcolorRect_handle = GCHandle.Alloc(mFrameData, GCHandleType.Pinned);
            //// ��ȡ�����ָ��  
            //mFrameDataPtr = bitmapcolorRect_handle.AddrOfPinnedObject();


            //MAME������BGRA32���úú�
            m_rawBufferWarper = new Texture2D(mWidth, mHeight, TextureFormat.BGRA32, false);
            //m_rawBufferWarper = new Texture2D(mWidth, mHeight, TextureFormat.ARGB32, false);
            m_rawBufferWarper.filterMode = FilterMode.Point;
        }

        //mFrameDataPtr = framePtr;
        m_drawCanvas.texture = m_rawBufferWarper;
        bInit = true;

        float targetWidth = ((float)mWidth / mHeight) * m_drawCanvasrect.rect.height;
        m_drawCanvasrect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, targetWidth);
    }

    public void StopVideo()
    {
        bInit = false;
        m_drawCanvas.color = new Color(0, 0, 0, 0);
    }

    void Update()
    {
        if (!bHadData)
            return;

        if (!bInit)
        {
            Initialize();
            return;
        }
        m_rawBufferWarper.LoadRawTextureData(mFrameDataPtr, mDataLenght);
        m_rawBufferWarper.Apply();
    }

    //public void SubmitVideo(int width, int height, byte[] data, long frame_number)
    public void SubmitVideo(int width, int height, IntPtr ptr, long frame_number)
    {

        mFrame = (ulong)frame_number;
        var current = Essgeeinit.sw.Elapsed;
        var delta = current - lastElapsed;
        lastElapsed = current;
        videoFPS = 1d / delta.TotalSeconds;
        //mFrameData = data;
        mFrameDataPtr = ptr;

        if (!bHadData)
        {
            mWidth = width;
            mHeight = height;
            bHadData = true;
        } 

        if (mWidth != width && mHeight != height)
        {
            
        }
        //Debug.Log($"frame_number -> {frame_number}");
    }

    public byte[] GetScreenImg()
    {
        return (m_drawCanvas.texture as Texture2D).EncodeToJPG();
    }
}
