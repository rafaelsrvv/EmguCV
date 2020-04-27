using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Novo_Emgucv
{
    public partial class Form1 : Form
    {
        MCvFont font = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_TRIPLEX,0.6d,0.6d);
        HaarCascade facedetected;
        Image<Bgr, Byte> Frame;
        Capture camera;
        Image<Gray, byte> result;
        Image<Gray, byte> TrainedFace = null;
        Image<Gray, byte> grayface = null;
        List<Image<Gray, byte>> trainingimages = new List<Image<Gray, byte>>();
        List<String> labels = new List<string>();
        List<String> Users = new List<string>();
        int Count, NumLables, t=0;
        string name, names = null;

        private void SalvarRosto_Click(object sender, EventArgs e)
        {
            Count = Count + 1;
            grayface = camera.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            MCvAvgComp[][] detectedfaces = grayface.DetectHaarCascade(facedetected, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
            foreach(MCvAvgComp f in detectedfaces[0])
            {
                TrainedFace = Frame.Copy(f.rect).Convert<Gray,Byte > ();
                break;
            }
            TrainedFace = result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            trainingimages.Add(TrainedFace);
            labels.Add(Nome.Text);
            File.WriteAllText(Application.StartupPath + "/Faces/Faces.txt", trainingimages.ToArray().Length.ToString() + ",");
            for(int i = 1; i<trainingimages.ToArray().Length + 1; i++)
            {
                trainingimages.ToArray()[i - 1].Save(Application.StartupPath + "/Faces/face" + i + ".bmp");
                File.AppendAllText(Application.StartupPath + "/Faces/Faces.txt", labels.ToArray()[i - 1] + ",");
            }
            MessageBox.Show(Nome.Text + "Salvo com sucesso");
        }

        public Form1()
        {
            
            InitializeComponent();
            //Haar cascade para detecção facial
            facedetected = new HaarCascade("haarcascade_frontalface_default.xml");
            try
            {
                string Labelsinf = File.ReadAllText(Application.StartupPath+"/Faces/Faces.txt");
                string[] Labels = Labelsinf.Split(',');
                NumLables = Convert.ToInt16(Labels[0]);
                Count = NumLables;
                string FacesLoad;
                for (int i=1; i<NumLables + 1; i++)
                {
                    FacesLoad = "face" + i + ".bpm";
                    trainingimages.Add(new Image<Gray, byte>(Application.StartupPath + "Faces/Faces.txt"));

                    labels.Add(Labels[1]);

                }
                //The first Label befora, will be the number of faces salved.

            }
            catch(Exception ex)
            {
                MessageBox.Show("NADA NO BANCO DE DADOS");
            }
        }

        private void LIGAR_Click(object sender, EventArgs e)
        { 
            camera = new Capture();
            camera.QueryFrame();
            Application.Idle += new EventHandler(FrameProcedure);



        }

        private void FrameProcedure(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Users.Add("");
            Frame = camera.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            grayface = Frame.Convert<Gray, Byte>();
            MCvAvgComp[][] facesDetectedNow = grayface.DetectHaarCascade(facedetected, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
            foreach (MCvAvgComp f in facesDetectedNow[0])
            {
                result=Frame.Copy(f.rect).Convert<Gray,Byte>().Resize(100,100,Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                Frame.Draw(f.rect, new Bgr(Color.Green), 3);
                if(trainingimages.ToArray().Length !=0)
                {
                    MCvTermCriteria termCriteria = new MCvTermCriteria(Count, 0.001);
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(trainingimages.ToArray(), labels.ToArray(), 1500, ref termCriteria);
                    name = recognizer.Recognize(result);
                    Frame.Draw(name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.Red));

                }
               // Users[t-1] = name;
                Users.Add("");
            }
            imageBox1.Image = Frame;
            names = "";
            Users.Clear();
        }
    }
}
