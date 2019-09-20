using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BlackboardPattern
{
    class Controller
    {
        Blackboard blackboard;
        List<IKnowledgeSource> KnowledgeSources = new List<IKnowledgeSource>();
        List<IKnowledgeSource> OrderedKnowledgeSources;

        public Controller(Blackboard board)
        {
            blackboard = board;

            KnowledgeSources.Add(theRadar);
            KnowledgeSources.Add(new SignalProcessor(DateTime.Now.Millisecond));
            KnowledgeSources.Add(new ImageRecognition());
            KnowledgeSources.Add(new PlaneIdentification());
            KnowledgeSources.Add(new WarMachine());

            OrderKnowledgeBases();

            foreach (var ks in OrderedKnowledgeSources)
                ks.Configure(blackboard);

            controlLoopTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            controlLoopTimer.Tick += new EventHandler(tick);
            controlLoopTimer.IsEnabled = true;
        }

        private void OrderKnowledgeBases()
        {
            OrderedKnowledgeSources = new List<IKnowledgeSource>(from ks in KnowledgeSources where ks.Priority > KnowledgeSourcePriority.Disabled orderby ks.Priority select ks);
        }

        void tick(object sender, EventArgs e)
        {
            foreach (IKnowledgeSource ks in OrderedKnowledgeSources)
                if (ks.IsEnabled)
                    ks.ExecuteAction();
        }

        internal void AddSignalProcessor()
        {
            var newProcessor = new SignalProcessor(DateTime.Now.Millisecond);
            newProcessor.Configure(blackboard);
            KnowledgeSources.Add(newProcessor);
            OrderKnowledgeBases();
        }
    }
}