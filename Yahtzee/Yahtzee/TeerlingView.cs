using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yahtzee
{
  public partial class TeerlingView : UserControl
  {
    private TeerlingController controller;
    private bool isOnHold = false;

    public TeerlingView(TeerlingController c)
    {
      InitializeComponent();
      controller = c;
    }

    public bool IsOnHold
    {
      get { return isOnHold; }
      set { isOnHold = value; }
    }

    private void TeerlingView_Load(object sender, EventArgs e)
    {
      HideWerpBtn();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      controller.Werp();

      int nieuwAantalOgen = controller.teerlingModel.AantalOgen;
      TeerlingLabel.Text = nieuwAantalOgen.ToString();
    }

    public void UpdateUI()
    {
      int nieuwAantalOgen = controller.teerlingModel.AantalOgen;
      TeerlingLabel.Text = nieuwAantalOgen.ToString();
    }

    public void HideWerpBtn()
    {
      TeerlingWerpBtn.Hide();
    }
    public void ShowWerpBtn()
    {
      TeerlingWerpBtn.Show();
    }

    public void ClearText()
    {
      TeerlingLabel.Text = "";
    }

    public void ResetHold()
    {
      holdBtn.BackColor = SystemColors.Control;
      isOnHold = false;
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
      if(!isOnHold)
      {
        isOnHold = true;
        holdBtn.BackColor = Color.Red;
      }
      else if(isOnHold)
      {
        isOnHold = false;
        holdBtn.BackColor = SystemColors.Control;
      }
    }
  }
}
