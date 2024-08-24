using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PokemonMauiApp.ViewModel
{
    /**
     * base vm: contains Title (title of page), IsBusy and IsNotBusy (for activity indicator)
     */
    public partial class BaseViewModel : ObservableObject
    {
        public BaseViewModel() { }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        bool isBusy;
        [ObservableProperty]
        string title;

        public bool IsNotBusy => !IsBusy;
    }
}
