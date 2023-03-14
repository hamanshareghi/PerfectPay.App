 namespace PerfectPay;

public partial class MainPage : ContentPage
{
    private decimal bill;
    private int tip;
    private int noPerson = 1;

	public MainPage()
	{
		InitializeComponent();
	}



    private void Calculate()
    {
        var totalTip = (bill * tip) / 100;
        var tipperPerson = totalTip / noPerson;
        lblTipPerson.Text = $"{tipperPerson:C}";

        var subTotal = bill / noPerson;
        lblTipPerson.Text = $"{subTotal:C}";

        var total = subTotal + tipperPerson;
        lblTotal.Text = $"{total:C}";
    }

    private void Slider_OnValueChanged(object sender, ValueChangedEventArgs e)
    {
        tip =(int)sldTip.Value;
        lblTip.Text = $"Tip:{tip}%";
        Calculate();
    }

    private void Minus_OnClicked(object sender, EventArgs e)
    {
        if (noPerson > 1)
        {
            noPerson--;
        }
        lblNoPerson.Text=noPerson.ToString();
        Calculate();
    }

    private void Plus_OnClicked(object sender, EventArgs e)
    {
        noPerson++;
        lblNoPerson.Text = noPerson.ToString();
        Calculate();    
    }

    private void Button_OnClicked(object sender, EventArgs e)
    {

        var btn = (Button) sender;
        var percentage = int.Parse(btn.Text.Replace("%", ""));
        sldTip.Value = percentage;
    }

    private void TxtBill_OnCompleted(object sender, EventArgs e)
    {
        bill = decimal.Parse(txtBill.Text);
        Calculate();
    }
}

