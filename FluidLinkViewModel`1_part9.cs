uOdehPSSViewModel>(new IPRModelBabuOdehPSSViewModel(this.DataSource.GetOrCreateDistributedCompletion(DistributedCompletionType.PSSBabuOdeh), (IFluidLinkViewModel) this));
          break;
        case IPRModelType.MultiPoint:
          this.IPRModelViewModel = (IIPRModelViewModel) this.RegisterContent<IPRModelMultiPointViewModel>(new IPRModelMultiPointViewModel(this.DataSource.GetOrCreateCompletionModel<MultiPointIPRModel>((Func<MultiPointIPRModel, bool>) null, (Action<MultiPointIPRModel>) null), (IFluidLinkViewModel) this));
          break;
        case IPRModelType.TrilinearTransientIPR:
          this.IPRModelViewModel = (IIPRModelViewModel) this.RegisterContent<IPRModelTrilinearViewModel>(new IPRModelTrilinearViewModel(this.DataSource.GetOrCreateCompletionModel<TrilinearTransientModel>((Func<TrilinearTransientModel, bool>) null, (Action<TrilinearTransientModel>) null), (IFluidLinkViewModel) this));
          break;
        default:
          throw new ArgumentException($"Unsupported IPRModelType='{this.IPRModelType.ToString()}'");
      }
    }
    this.RegisterSubscription((ISubscription) new CollectionChangedSubscription((INotifyCollectionChanged) this.DataSource.TestData, new NotifyCollectionChangedEventHandler(this.TestData_CollectionChanged)));
    this.PopulateTestData();
  }

  private void UpdateListeners()
  {
    Interlocked.Exchange<List<ISubscription>>(ref this._transientSubscriptionList, new List<ISubscription>())?.ForEach((Action<ISubscription>) (x => this.UnregisterSubscription(x)));
    WellString wellString = this.DataSource.WellString;
    if (!(wellString != (WellString) null))
      return;
    this._transientSubscriptionList.Add(this.RegisterSubscription((ISubscription) new DomainObjectChangedSubscription((OdtDomainObjectBase) wellString, new EventHandler<DomainObjectChangeEventArgs>(this.WellString_Changed))));
    this._transientSubscriptionList.Add(this.RegisterSubscription((ISubscription) new CollectionChangedSubs
