using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CuttingRoom
{
    public partial class OutputSelectionDecisionPoint : DecisionPoint
    {
        /// <summary>
        /// Method container for the output selection method for this decision point.
        /// </summary>
        [SerializeField]
        public MethodContainer methodContainer = new();

        /// <summary>
        /// Unity event invoked by engine.
        /// </summary>
        private void Awake()
        {
            methodContainer.methodClass = typeof(OutputSelectionDecisionPoint).AssemblyQualifiedName;

            methodContainer.Init();
        }

        /// <summary>
        /// Processing routine for the output selection decision point.
        /// </summary>
        /// <param name="onSelection"></param>
        /// <returns></returns>
        public override IEnumerator Process(Sequencer sequencer, OnSelectionCallback onSelection)
        {
            // If the output selection method is known.
            if (methodContainer.Initialised)
            {
                // If there are some candidates to select from.
                if (candidates.Count > 0)
                {
                    // Get the valid candidates based on constraints.
                    List<NarrativeObject> validCandidates = ProcessConstraints(sequencer, constraints);

                    MethodContainer.Args args = new MethodContainer.Args { onSelection = onSelection, candidates = validCandidates };

                    // Start the selection method in a new coroutine and wait for it to complete.
                    yield return StartCoroutine(methodContainer.methodInfo.Name, args);
                }
            }
        }

        public override IEnumerator Process(Sequencer sequencer, OnMultiSelectionCallback onSelection)
        {
            // Not implemented
            throw new NotImplementedException("Process() not implemented for multi selection on groups.");
        }
    }
}
