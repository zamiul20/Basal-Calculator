using Calculator;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void GoToCalc(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//" + nameof(Calc_Page)); ;
        }
        private async void GoToCon(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//" + nameof(Convert_Page)); ;
        }
        private async void GoToZam(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//" + nameof(Zaming_Page)); ;
        }

    }
}
