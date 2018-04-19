namespace NET.W._2018.Соколовский._13.Models
{
    public class TreeNode<T>
    {
        public TreeNode(T data)
        {
            this.Data = data;
        }

        /// <summary>
        /// Gets and sets value of current node.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Gets and sets left branch of current node.
        /// </summary>
        public TreeNode<T> Left { get; set; }

        /// <summary>
        /// Gets and sets right branch of current node.
        /// </summary>
        public TreeNode<T> Right { get; set; }
    }
}