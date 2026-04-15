using Calculator;

namespace Calculator
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Calc_Page), typeof(Calc_Page));
            Routing.RegisterRoute(nameof(Convert_Page), typeof(Convert_Page));
        }
    }
}
