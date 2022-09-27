namespace Checkpoint2EE.Entidades
{
    class Gerente : Funcionario
    {
        public override double CalcularPagamento(List<Pedido> pedidos)
        {
            double comissoes = 0;
            foreach (Pedido pedido in pedidos)
            {
                comissoes += pedido.Valor * 0.05;
            }
            return Salario + comissoes;
        }
    }
}
