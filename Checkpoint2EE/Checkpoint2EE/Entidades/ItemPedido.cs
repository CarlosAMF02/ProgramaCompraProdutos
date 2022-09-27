namespace Checkpoint2EE.Entidades
{
    class ItemPedido
    {
        public int Quantidade { get; set; }
        public double Valor { get; set; }
        public Produto Produto { get; set; }

        public double Subtotal()
        {
            return Quantidade * Valor;
        }
    }
}
