namespace NET.W._2018.Соколовский._13.Models
{
    public class TreeNode<T>
    {
        public TreeNode(T data)
        {
            this.Data = data;
        }

        public T Data { get; set; }

        public TreeNode<T> Left { get; set; }

        public TreeNode<T> Right { get; set; }
    }
}