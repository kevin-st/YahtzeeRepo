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
  public partial class MPScoreView : UserControl
  {
    private MPScoreController controller;

    public MPScoreView(MPScoreController c)
    {
      InitializeComponent();
      controller = c;
    }

    Label[] P1Labels = new Label[7];
    Label[] P2Labels = new Label[7];

    private void MPScoreView_Load(object sender, EventArgs e)
    {
      P1Labels[0] = P1G1;
      P1Labels[1] = P1G2;
      P1Labels[2] = P1G3;
      P1Labels[3] = P1G4;
      P1Labels[4] = P1G5;
      P1Labels[5] = P1G6;
      P1Labels[6] = P1G7;

      P2Labels[0] = P2G1;
      P2Labels[1] = P2G2;
      P2Labels[2] = P2G3;
      P2Labels[3] = P2G4;
      P2Labels[4] = P2G5;
      P2Labels[5] = P2G6;
      P2Labels[6] = P2G7;

      for (int i = 3; i < P1Labels.Length; i++)
      {
        P1Labels[i].Hide();
        P2Labels[i].Hide();
      }
    }

    public void showBestOf3()
    {
      for (int i = 0; i < 3; i++)
      {
        P1Labels[i].Show();
        P2Labels[i].Show();
      }
      for (int i = 3; i < P1Labels.Length; i++)
      {
        P1Labels[i].Hide();
        P2Labels[i].Hide();
      }
    }
    public void showBestOf5()
    {
      for (int i = 0; i < 5; i++)
      {
        P1Labels[i].Show();
        P2Labels[i].Show();
      }
      for (int i = 5; i < P1Labels.Length; i++)
      {
        P1Labels[i].Hide();
        P2Labels[i].Hide();
      }
    }
    public void showBestOf7()
    {
      for (int i = 0; i < P1Labels.Length; i++)
      {
        P1Labels[i].Show();
        P2Labels[i].Show();
      }
    }

    private void bestOf3Radio_CheckedChanged(object sender, EventArgs e)
    {
      if ( bestOf3Radio.Checked )
      {
        showBestOf3();
        controller.mpScoreModel.MaxScore = 2;
      }
    }

    private void bestOf5Radio_CheckedChanged(object sender, EventArgs e)
    {
      if (bestOf5Radio.Checked)
      {
        showBestOf5();
        controller.mpScoreModel.MaxScore = 3;
      }
    }

    private void bestOf7Radio_CheckedChanged(object sender, EventArgs e)
    {
      if (bestOf7Radio.Checked)
      {
        showBestOf7();
        controller.mpScoreModel.MaxScore = 4;
      }
    }

    public void UpdateScoreP1Win()
    {
      P1Labels[controller.mpScoreModel.GameNumber].Text = "1";
      P2Labels[controller.mpScoreModel.GameNumber].Text = "0";
    }
    public void UpdateScoreP2Win()
    {
      P1Labels[controller.mpScoreModel.GameNumber].Text = "0";
      P2Labels[controller.mpScoreModel.GameNumber].Text = "1";
    }
  }
}
