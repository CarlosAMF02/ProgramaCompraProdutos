namespace Checkpoint2EE.Entidades
{
    class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }

        public override string ToString()
        {
            return $"{Id} - {Nome}: R$ {Valor:F2}";
        }
    }
}
