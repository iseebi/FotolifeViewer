using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using FotolifeViewer.Core.Models;

namespace FotolifeViewer.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
                static readonly string LogTag = "FirstViewModel";

        public IEnumerable<HatenaFotolifeItem> Items
        {
            get { return _items; } 
            private set
            {
                _items = value;
                RaisePropertyChanged(() => Items);
            }
        }

        IEnumerable<HatenaFotolifeItem> _items;

        public IMvxCommand ReloadCommand { get; private set; }

        public FirstViewModel()
        {
            ReloadCommand = new MvxCommand(async () => await Reload());
        }

        public override async void Start()
        {
            base.Start();
            await Reload();
        }

        async Task Reload()
        {
            try
            {
                var items =  await HatenaFotolife.FetchHotfotosAsync();
                Items = items;
            }
            catch (Exception e)
            {
                // TODO: エラーのメッセージを投げる
                Mvx.TaggedWarning(LogTag, "Reload Exception: {0}", e.ToString());
            }
        }
    }
}
