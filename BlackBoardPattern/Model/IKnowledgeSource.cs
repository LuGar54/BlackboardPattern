using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackboardPattern
{
    interface IKnowledgeSource
    {
        KnowledgeSourceType KSType { get; }
        KnowledgeSourcePriority Priority { get; }
        bool IsEnabled { get; }

        void Configure(Blackboard board);
        void Stop();

        void ExecuteAction();
    }
}