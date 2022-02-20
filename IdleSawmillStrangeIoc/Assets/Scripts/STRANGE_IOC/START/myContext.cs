using System.Collections;
using System.Collections.Generic;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;

public class myContext : MVCSContext
{
    public myContext(MonoBehaviour view) : base(view)
    {
        
    }
    
    protected override void mapBindings()
    {
        base.mapBindings();
       

          injectionBinder.Bind<iSaveData>().To<saveDataModel>().ToSingleton();
          injectionBinder.Bind<iForest>().To<forestController>().ToSingleton();
      

        commandBinder.Bind(ContextEvent.START).To<dataLoader>().To<appStartCommand>().Once();
          
          
        mediationBinder.Bind<levelView>().To<levelMediator>();
        mediationBinder.Bind<uiView>().To<uiMediator>();
        mediationBinder.Bind<upPanelUIView>().To<upPanelUIMediator>();
        mediationBinder.Bind<downPanelUIView>().To<downPanelUIMediator>();
        mediationBinder.Bind<levelPrefabView>().To<levelPrefabMediator>();
        mediationBinder.Bind<forestView>().To<forestMediator>();
        mediationBinder.Bind<sawmillView>().To<sawmillMediator>();
        mediationBinder.Bind<lumberjackView>().To<lumberjackMediator>();

        commandBinder.Bind(myEvents.MONEY_UPDATE).To<moneyChangeCommand>();
        commandBinder.Bind(myEvents.LEVEL_UPDATE).To<levelChangeCommand>();
        commandBinder.Bind(myEvents.INCREASE_PRICE).To<increasePriceCommand>();
        commandBinder.Bind(myEvents.INCREASE_SPEED).To<increaseSpeedCommand>();
        commandBinder.Bind(myEvents.INCREASE_SAWMILL).To<increaseSawmillCommand>();
        commandBinder.Bind(myEvents.REGENERATE_FOREST).To<regenerateForestCommand>();
    }
    
    protected override void addCoreComponents()
    {
        base.addCoreComponents();
        injectionBinder.Unbind<ICommandBinder>(); //Unbind to avoid a conflict!
        injectionBinder.Bind<ICommandBinder>().To<EventCommandBinder>().ToSingleton();
    }
}
