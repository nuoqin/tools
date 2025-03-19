using Wpf.Ui.Controls;

namespace nuoqin.src.Pages
{
    /// <summary>
    /// HomePage.xaml 的交互逻辑
    /// </summary>
    public partial class HomePage : INavigableView<Model.HomeViewModel>
    {
        public Model.HomeViewModel ViewModel { get; }

        public HomePage(Model.HomeViewModel viewModel)
        {
            ViewModel = viewModel;
            DataContext = this;
            InitializeComponent();
        }
    }
}
