using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackboardPattern
{
    class TextWatcher : KnowledgeSourceBase
    {
        public TextWatcher()
        {

        }

        public override void Configure(Blackboard board)
        {
            base.Configure(board);


        }

        public override KnowledgeSourceType KSType => KnowledgeSourceType.Detector;




    }
}