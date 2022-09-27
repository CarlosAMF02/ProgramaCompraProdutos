namespace Checkpoint2EE.Entidades
{
    abstract class Funcionario
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public double Salario { get; set; }

        public override string ToString()
        {
            return $"{Matricula} - {Nome}: R${Salario:F2}";
        }

        public abstract double CalcularPagamento(List<Pedido> pedidos);
    }
}
