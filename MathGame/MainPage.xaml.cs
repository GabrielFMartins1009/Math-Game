namespace MathGame
{
    public partial class MainPage : ContentPage
    {
       

        int iLB1 = 0;
        int iLB2 = 0;
        int iLB3 = 0;  
        float fR = 0.0f;
        int iAcertouCont = 0;
        int iErrouCont = 0;
        Random rand = new Random();


        public MainPage()
        {
            InitializeComponent();
            GerarJogo();
        }

        private async void btOK_Clicked(object sender, EventArgs e)
        {

            float fResult = 0.0f;

            try
            {
                fResult = float.Parse(txR.Text);
            }
            catch (Exception ex)
            {

                await DisplayAlert("Erro", "Digite um número válido!", "OK");
                return;

            }

            if (fResult == fR)
            {
                iAcertouCont++;
                lbAcertou.Text = "Acertos: " + Convert.ToString(iAcertouCont);
                imR.Source = "win.png";
                GerarJogo();


            }
            else if (fResult != fR)
            {
                iErrouCont++;
                lbErrou.Text = "Erros: " + Convert.ToString(iErrouCont);
                imR.Source = "loose.png";
                GerarJogo();

            }

            await Task.Delay(2000);
            imR.Source = "question.png";
        }





        private void GerarJogo()
        { 
           iLB1 = rand.Next(1, 10);
           iLB2 = rand.Next(1, 5);
           iLB3 = rand.Next(1, 10);

           lb1.Text = Convert.ToString(iLB1);
           lb3.Text = Convert.ToString(iLB3);

            switch (iLB2)
            {
                case 1:
                    lb2.Text = "+";
                    fR = iLB1 + iLB3;
                    break;

                case 2:
                     lb2.Text = "-";
                    fR = iLB1 - iLB3;
                    break;

                case 3:
                    lb2.Text = "*";
                    fR = iLB1 * iLB3;
                    break;

                case 4:
                    lb2.Text = "/";
                    fR = iLB1 / iLB3;
                    break;

            }

            txR.Text = "";

        }



    }
}
