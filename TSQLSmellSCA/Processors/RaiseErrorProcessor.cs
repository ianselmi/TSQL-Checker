using Microsoft.SqlServer.TransactSql.ScriptDom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSQLSmellSCA
{
    public class RaiseErrorProcessor
    {
        private Smells _smells;

        public RaiseErrorProcessor(Smells smells)
        {
            _smells = smells;
        }

        public void RaiseErrorDefinition(RaiseErrorStatement raiseErrorStm)
        {
            if(((StringLiteral)raiseErrorStm.FirstParameter).Value.Contains("%i") && raiseErrorStm.OptionalParameters.Count > 0)
            {
                if (raiseErrorStm.OptionalParameters[0] is VariableReference)
                {
                    VariableTypeDefinition variableValue = _smells.DeclareVariableProcessor.VariableList.Find(x => x.Name == ((VariableReference)raiseErrorStm.OptionalParameters[0]).Name);
                    if(variableValue != null && variableValue.Type != SqlDataTypeOption.BigInt)
                    {
                        _smells.SendFeedBack(51, raiseErrorStm);
                    }
                }                
            }
        }
    }
}
