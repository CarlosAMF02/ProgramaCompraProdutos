namespace Checkpoint2EE.Entidades
{
    class Vendedor : Funcionario
    {
        public override double CalcularPagamento(List<Pedido> pedidos)
        {
            double comissoes = 0;
            foreach (Pedido pedido in pedidos)
            {
                if (pedido.Funcionario.Matricula == Matricula)
                {
                    comissoes += pedido.Valor * 0.1;
                }
            }
            return Salario + comissoes;
        }
    }
}
