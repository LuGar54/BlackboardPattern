using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackboardPattern
{
    public abstract class KnowledgeSourceBase : IKnowledgeSource
    {
        internal Blackboard blackboard;

        public abstract KnowledgeSourceType KSType { get; }

        public virtual void ExecuteAction()
        {
            //Do nothing by default, for autonomous modules
        }

        public virtual bool IsEnabled
        {
            get
            {
                return true;
            }
        }

        public virtual KnowledgeSourcePriority Priority
        {
            get { return KnowledgeSourcePriority.Normal; }
        }

        public virtual void Configure(Blackboard board)
        {
            blackboard = board;
        }

        public virtual void Stop()
        {
        }
    }
}