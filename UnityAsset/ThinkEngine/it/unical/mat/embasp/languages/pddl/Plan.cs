﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace EmbASP4Unity.it.unical.mat.embasp.languages.pddl
{
	using Output = it.unical.mat.embasp.@base.Output;
	
  public abstract class Plan : Output
	{
		protected internal IList<Action> actionSequence;
		private IList<object> actionsObjects;

		public Plan(string plan, string error) : base(plan, error) { }

    public virtual IList<Action> Actions {
      get {
        if (actionSequence == null) {
          actionSequence = new List<Action>();
          Parse();
        }
        return new ReadOnlyCollection<Action>(actionSequence);
      }
    }

    public virtual IList<object> ActionsObjects {
      get {
        if (actionsObjects == null) {
          actionsObjects = new List<object>();
          PDDLMapper mapper = PDDLMapper.Instance;
        //Console.WriteLine("OK");
          foreach (Action a in Actions) {
            object obj = mapper.GetObject(a.Name);
            //Console.WriteLine(obj.ToString());
            if (obj != null)
              actionsObjects.Add(obj);
          }
        }
        //Console.WriteLine(actionsObjects.ToString());
        return actionsObjects;
      }
    }
  }
}