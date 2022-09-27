using Checkpoint2EE.Entidades.Enums;

namespace Checkpoint2EE.Entidades
{
    class Pedido
    {
        public DateTime DataPedido { get; set; }
        public double Valor { get; set; }
        public StatusPedido Status { get; set; }
        public List<ItemPedido> ItemPedidos { get; set; }
        public Funcionario Funcionario { get; set; }

        public override string ToString()
        {
            return $"{DataPedido} - R${Valor:F2} - {Status.ToString()} - {ItemPedidos.Count} - {Funcionario.Matricula}";
        }

        public void AdicionarItem(ItemPedido itemPedido)
        {
            if (ItemPedidos == null)
            {
                ItemPedidos = new List<ItemPedido>();
            }

            Valor += itemPedido.Subtotal();
            ItemPedidos.Add(itemPedido);
        }
    }
}
