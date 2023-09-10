using System.Data;

namespace Erstes_Fenster
{
    public partial class bt_ClickMe : Form
    {
        public bt_ClickMe()
        {
            InitializeComponent();
        }



        static public int anzahlStellen = 14;
        static public decimal zahl1;
        static public decimal zahl2;
        static public decimal ergebnis;
        static public decimal ergebnis_Gerundet;
        public bool istgleich_Zeichen_Vorhanden;
        public bool operator_Uebernimmt_IstGleichRolle = false;
        public bool klick_Auf_Btn_Zahl_Nach_IstGleichRolle = false;

        // Buttons
        public bool addieren = false;
        public bool subtrahieren = false;
        public bool multiplizieren = false;
        public bool dividieren = false;
        public bool istgleich = false;


        //string ergebnis_rechtsbündig = $"{ergebnis,15:N0}";

        private void bt_Addieren_Click(object sender, EventArgs e) // Addieren
        {
            istgleich_Zeichen_Vorhanden = textBox_Rechenweg.Text.Contains("=");
            if (decimal.TryParse(textBox_Ergebnis.Text, out zahl1))
            {
                if (string.IsNullOrEmpty(textBox_Rechenweg.Text) || istgleich_Zeichen_Vorhanden == true)
                {
                addieren = true;
                subtrahieren = false;
                multiplizieren = false;
                dividieren = false;
                textBox_Rechenweg.Text = $"{zahl1} +";
                textBox_Zahl1.Text = textBox_Ergebnis.Text;
                textBox_Ergebnis.Clear();
                textBox_Ergebnis.Visible = false;                
                }
                else if(!string.IsNullOrEmpty(textBox_Rechenweg.Text) && istgleich_Zeichen_Vorhanden == false) 
                {
                    if(decimal.TryParse(textBox_Zahl1.Text, out zahl2) && addieren == true && klick_Auf_Btn_Zahl_Nach_IstGleichRolle == false)
                    {
                        //addieren = true;
                        //subtrahieren = false;
                        //multiplizieren = false;
                        //dividieren = false;
                        ergebnis = zahl1 + zahl2;
                        ergebnis_Gerundet = decimal.Round(ergebnis, anzahlStellen);
                        textBox_Ergebnis.Text = ergebnis_Gerundet.ToString();
                        textBox_Zahl1.Text = ergebnis_Gerundet.ToString(); // vergibt an Zahl1 das Ergebnis und aktualisiert somit die Zahl im Hintergrund 
                        textBox_Rechenweg.Text = $"{ergebnis} + ";
                        istgleich = true;
                        operator_Uebernimmt_IstGleichRolle = true;
                    }

                    if (decimal.TryParse(textBox_Zahl1.Text, out zahl2) && addieren == true && klick_Auf_Btn_Zahl_Nach_IstGleichRolle == true)
                    {
                        //addieren = true;
                        //subtrahieren = false;
                        //multiplizieren = false;
                        //dividieren = false;
                        zahl1 = ergebnis;
                        ergebnis = zahl1 + zahl2;
                        ergebnis_Gerundet = decimal.Round(ergebnis, anzahlStellen);

                    }

                }
            }

        }

        private void bt_Subtrahieren_Click(object sender, EventArgs e) // Subtrahieren
        {
            if (decimal.TryParse(textBox_Ergebnis.Text, out zahl1))
            {
                subtrahieren = true;
                addieren = false;
                multiplizieren = false;
                dividieren = false;
                textBox_Rechenweg.Text = $"{zahl1} -";
                textBox_Zahl1.Text = textBox_Ergebnis.Text;
                textBox_Ergebnis.Clear();
                textBox_Ergebnis.Visible = false;
            }
        }

        private void bt_Multiplizieren_Click(object sender, EventArgs e) // Multiplizieren
        {
            if (decimal.TryParse(textBox_Ergebnis.Text, out zahl1))
            {
                multiplizieren = true;
                addieren = false;
                subtrahieren = false;
                dividieren = false;
                textBox_Rechenweg.Text = $"{zahl1} x";
                textBox_Zahl1.Text = textBox_Ergebnis.Text;
                textBox_Ergebnis.Clear();
                textBox_Ergebnis.Visible = false;
            }
        }

        private void bt_Dividieren_Click(object sender, EventArgs e) // Dividieren
        {
            if (decimal.TryParse(textBox_Ergebnis.Text, out zahl1))
            {
                dividieren = true;
                addieren = false;
                subtrahieren = false;
                multiplizieren = false;
                textBox_Rechenweg.Text = $"{zahl1} /";
                textBox_Zahl1.Text = textBox_Ergebnis.Text;
                textBox_Ergebnis.Clear();
                textBox_Ergebnis.Visible = false;
            }
        }

        private async void bt_IstGleich_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBox_Ergebnis.Text, out zahl2) && addieren == true) // Addieren
            {
                ergebnis = zahl1 + zahl2;
                ergebnis_Gerundet = decimal.Round(ergebnis, anzahlStellen);
                textBox_Ergebnis.Text = ergebnis_Gerundet.ToString();
                textBox_Zahl1.Text = ergebnis_Gerundet.ToString(); // vergibt an Zahl1 das Ergebnis und aktualisiert somit die Zahl im Hintergrund 
                textBox_Rechenweg.Text = $"{zahl1} + {zahl2} =";
                istgleich = true;
                //addieren = false;
                //subtrahieren = false;
                //multiplizieren = false;
                //dividieren = false;
            }

            if (decimal.TryParse(textBox_Ergebnis.Text, out zahl2) && subtrahieren == true) // Subtrahieren
            {
                ergebnis = zahl1 - zahl2;
                ergebnis_Gerundet = decimal.Round(ergebnis, anzahlStellen);
                textBox_Ergebnis.Text = ergebnis_Gerundet.ToString();
                textBox_Zahl1.Text = ergebnis_Gerundet.ToString();
                textBox_Rechenweg.Text = $"{zahl1} - {zahl2} =";
                istgleich = true;
                //addieren = false;
                //subtrahieren = false;
                //multiplizieren = false;
                //dividieren = false;
            }

            if (decimal.TryParse(textBox_Ergebnis.Text, out zahl2) && multiplizieren == true) // Multiplizieren
            {
                ergebnis = zahl1 * zahl2;
                ergebnis_Gerundet = decimal.Round(ergebnis, anzahlStellen);
                textBox_Ergebnis.Text = ergebnis_Gerundet.ToString();
                textBox_Zahl1.Text = ergebnis_Gerundet.ToString();
                textBox_Rechenweg.Text = $"{zahl1} x {zahl2} =";
                istgleich = true;
                //addieren = false;
                //subtrahieren = false;
                //multiplizieren = false;
                //dividieren = false;
            }

            if (decimal.TryParse(textBox_Ergebnis.Text, out zahl2) && dividieren == true && zahl2 != 0) // Dividieren
            {
                ergebnis = zahl1 / zahl2;
                ergebnis_Gerundet = decimal.Round(ergebnis, anzahlStellen);
                textBox_Ergebnis.Text = ergebnis_Gerundet.ToString();
                textBox_Zahl1.Text = ergebnis_Gerundet.ToString();
                textBox_Rechenweg.Text = $"{zahl1} / {zahl2} =";
                istgleich = true;
                //addieren = false;
                //subtrahieren = false;
                //multiplizieren = false;
                //dividieren = false;
            }
            else if (decimal.TryParse(textBox_Ergebnis.Text, out zahl2) && dividieren == true && zahl2 == 0)
            {
                label_TeilungDurchNull.Visible = true;
                await Task.Delay(1000);
                label_TeilungDurchNull.Visible = false;
                istgleich = true;
                //addieren = false;
                //subtrahieren = false;
                //multiplizieren = false;
                //dividieren = false;
            }
        }

        private void bt_Komma_Click(object sender, EventArgs e)
        {
            textBox_Ergebnis.Text = textBox_Ergebnis.Text + ",";
        }

        private void bt_Backspace_Click(object sender, EventArgs e)
        {
            if (textBox_Ergebnis.Text.Length >= 1)
            {
                textBox_Ergebnis.Text = textBox_Ergebnis.Text.Remove(textBox_Ergebnis.Text.Length - 1);
            }
        }

        private void bt_Loeschen_Click(object sender, EventArgs e)
        {
            textBox_Ergebnis.Clear();
            textBox_Rechenweg.Clear();
            textBox_Zahl1.Clear();
            addieren = false;
            subtrahieren = false;
            multiplizieren = false;
            dividieren = false;
        }

        private void btn_Click(object sender, EventArgs e) // 0 - 9
        {
            Button btn = (Button)sender;
            textBox_Ergebnis.Visible = true;
            if (textBox_Ergebnis.Text.Length < 16 && istgleich == false)
            {
                textBox_Ergebnis.Text = textBox_Ergebnis.Text + btn.Text;
            }
            else if (textBox_Ergebnis.Text.Length < 16 && istgleich == true && operator_Uebernimmt_IstGleichRolle == false)
            {
                textBox_Ergebnis.Clear();
                textBox_Zahl1.Clear();
                textBox_Ergebnis.Text = btn.Text;
                //textBox_Rechenweg.Clear();
                istgleich = false;
                //label_TeilungDurchNull.Visible = true;
                //await Task.Delay(1000);
                //label_TeilungDurchNull.Visible = false;
            }
            else if (textBox_Ergebnis.Text.Length < 16 && istgleich == true && operator_Uebernimmt_IstGleichRolle == true)
            {
                textBox_Rechenweg.Text = $"{ergebnis} +";
                textBox_Ergebnis.Clear();
                textBox_Zahl1.Clear();
                textBox_Ergebnis.Text = btn.Text;
                //label_TeilungDurchNull.Visible = true;
                //await Task.Delay(1000);
                //label_TeilungDurchNull.Visible = false;
                operator_Uebernimmt_IstGleichRolle = false;
                klick_Auf_Btn_Zahl_Nach_IstGleichRolle = true;
            }


        }

        private void textBox_Ergebnis_TextChanged(object sender, EventArgs e)
        {
            //textBox_Ergebnis
        }
        private void textBox_Rechenweg_TextChanged(object sender, EventArgs e)
        {
            //textBox_Rechenweg
        }
        private void textBox_Zahl1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}