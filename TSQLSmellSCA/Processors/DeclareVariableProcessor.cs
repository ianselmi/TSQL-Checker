using Microsoft.SqlServer.TransactSql.ScriptDom;
using System.Collections.Generic;

namespace TSQLSmellSCA
{
    public class DeclareVariableProcessor
    {
        private Smells _smells;
        public List<VariableTypeDefinition> VariableList { get; private set; }

        public DeclareVariableProcessor(Smells smells)
        {
            _smells = smells;
            VariableList = new List<VariableTypeDefinition>();
        }

        public void ProcessDeclareVariableElement(DeclareVariableElement Element)
        {
            if (Element.VariableName.Value.Length <= 2)
            {
                _smells.SendFeedBack(33, Element);
            }
            _smells.ProcessTsqlFragment(Element.DataType);
            VariableList.Add(new VariableTypeDefinition
            {
                
                Name = Element.VariableName.Value,
                Type = ((SqlDataTypeReference)Element.DataType).SqlDataTypeOption
            });
            if (Element.Value != null) _smells.ProcessTsqlFragment(Element.Value);
        }

        public void ProcessDeclareVariableStatement(DeclareVariableStatement Statement)
        {
            foreach (DeclareVariableElement variable in Statement.Declarations)
            {
                _smells.ProcessTsqlFragment(variable);
            }
        }
    }

    public class VariableTypeDefinition
    {
        public string Name { get; set; }
        public SqlDataTypeOption Type { get; set; }
    }
}