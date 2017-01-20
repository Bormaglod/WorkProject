//-----------------------------------------------------------------------
// <copyright file="DbTreeView.cs" company="Sergey Teplyashin">
//     Copyright (c) 2010-2015 Sergey Teplyashin. All rights reserved.
// </copyright>
// <author>Тепляшин Сергей Васильевич</author>
// <email>sergio.teplyashin@gmail.com</email>
// <license>
//     This program is free software; you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation; either version 3 of the License, or
//     (at your option) any later version.
//
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
//
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.
// </license>
// <date>12.11.2014</date>
// <time>7:59</time>
// <summary>Defines the DbTreeView class.</summary>
//-----------------------------------------------------------------------

namespace WorkProject.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows.Forms;
    using ComponentFactory.Krypton.Toolkit;
    using WorkProject.Data.Base;
    
    public class GroupTreeView : KryptonTreeView
    {
        class NodeData
        {
            string name;
            readonly TreeNode node;
            int count;
            
            public NodeData(ITreeItem item, TreeNode node)
            {
                this.node = node;
                Item = item;
                if (Item == null)
                {
                    name = node.Text;
                }
            }
            
            public NodeData(ITreeItem item, TreeNode node, int countItems) : this(item, node)
            {
                count = countItems;
            }
            
            public ITreeItem Item { get; set; }
            
            public TreeNode Node
            {
                get { return node; }
            }
            
            public int Count
            {
                get
                {
                    return count;
                }
                
                set
                {
                    count = value;
                    node.Text = ToString(true);
                }
            }
            
            public override string ToString()
            {
                return Item == null ? name : Item.Name;
            }

            public string ToString(bool countData)
            {
                return countData ? string.Format("{0} ({1})", ToString(), Count) : ToString();
            }
        }

        readonly List<NodeData> nodes;
        bool countData;
        
        public GroupTreeView()
        {
            nodes = new List<NodeData>();
        }
        
        public event EventHandler<CountItemsEventArgs> CountItems;
        
        [Browsable(false)]
        public int SelectedId
        {
            get
            {
                if (SelectedNode != null)
                {
                    NodeData d = nodes.SingleOrDefault(x => x.Node == SelectedNode);
                    if (d != null && d.Item != null)
                    {
                        return d.Item.Id;
                    }
                }
                
                return 0;
            }
            
            set
            {
                if (value > 0)
                {
                    NodeData d = nodes.SingleOrDefault(x => x.Item.Id == value);
                    if (d != null)
                    {
                        SelectedNode = d.Node;
                        return;
                    }
                }

                if (Nodes.Count > 0)
                {
                    SelectedNode = Nodes[0];
                }
            }
        }
        
        [Browsable(false)]
        public ITreeItem SelectedItem
        {
            get
            {
                if (SelectedNode != null)
                {
                    NodeData d = nodes.SingleOrDefault(x => x.Node == SelectedNode);
                    if (d != null)
                    {
                        return d.Item;
                    }
                }
                
                return null;
            }
            
            set
            {
                if (SelectedNode != null && value != null)
                {
                    NodeData d = nodes.SingleOrDefault(x => x.Node == SelectedNode);
                    if (d != null)
                    {
                        d.Item = value;
                        RefreshSelectedItem();
                    }
                }
            }
        }
        
        [Browsable(false)]
        public int ParentId
        {
            get
            {
                if (SelectedNode == null || SelectedNode.Parent == null)
                {
                    return 0;
                }
                
                NodeData d = nodes.SingleOrDefault(x => x.Node == SelectedNode.Parent);
                return d == null || d.Item == null ? 0 : d.Item.Id;
            }
        }
        
        [Browsable(false)]
        public ITreeItem ParentItem
        {
            get
            {
                if (SelectedNode == null || SelectedNode.Parent == null)
                {
                    return null;
                }
                
                NodeData d = nodes.SingleOrDefault(x => x.Node == SelectedNode.Parent);
                return d == null ? null : d.Item;
            }
        }
        
        [Browsable(false)]
        public bool CountDataContains
        {
            get
            {
                return countData;
            }
            
            set
            {
                if (countData != value)
                {
                    countData = value;
                    foreach (NodeData n in nodes)
                    {
                        n.Node.Text = n.ToString(countData);
                    }
                }
            }
        }
        
        NodeData SelectedData
        {
            get
            {
                return SelectedNode != null ? nodes.SingleOrDefault(x => x.Node == SelectedNode) : null;
                
            }
        }
        
        public void IncrementContentSelected()
        {
            NodeData d = SelectedData;
            if (d != null)
            {
                d.Count++;
            }
        }
        
        public void DecrementContentSelected()
        {
            NodeData d = SelectedData;
            if (d != null)
            {
                d.Count--;
            }
        }
        
        public void AddItems<T>(IList<T> items, string header) where T: ITreeItem
        {
            Clear();
            TreeNode node = Nodes.Add(header);
            int c = GetCountItems(null);
            nodes.Add(new NodeData(null, node, c));
            if (countData)
            {
                node.Text += string.Format(" ({0})", c);
            }
            
            AddItems<T>(items, node);
            ExpandAll();
            SelectedNode = Nodes[0];
        }
        
        public void Clear()
        {
            Nodes.Clear();
            nodes.Clear();
        }
        
        public void RefreshSelectedItem()
        {
            NodeData d = SelectedData;
            if (d != null)
            {
                d.Node.Text = d.ToString(countData);
            }
        }
        
        public void AddItem(ITreeItem item)
        {
            if (item.Parent_Id.HasValue && item.Parent_Id.Value != 0)
            {
                NodeData d = nodes.SingleOrDefault(x => x.Item != null && x.Item.Id == item.Parent_Id.Value);
                if (d != null)
                {
                    nodes.Add(new NodeData(item, d.Node.Nodes.Add(item.ToString())));
                    d.Node.ExpandAll();
                    return;
                }
            }
            
            nodes.Add(new NodeData(item, Nodes[0].Nodes.Add(item.ToString())));
        }

        public void RemoveItem(ITreeItem item)
        {
            NodeData d = nodes.SingleOrDefault(x => x.Item != null && x.Item.Id == item.Id);
            if (d != null)
            {
                Nodes.Remove(d.Node);
                nodes.Remove(d);
            }
        }
        
        public void MoveItem(ITreeItem item)
        {
            NodeData d_cur = nodes.SingleOrDefault(x => x.Item != null && x.Item.Id == item.Id);
            Nodes.Remove(d_cur.Node);
            
            TreeNode parentNode;
            if (item.Parent_Id.HasValue)
            {
                NodeData d_parent = nodes.SingleOrDefault(x => x.Item != null && x.Item.Id == item.Parent_Id);
                parentNode = d_parent.Node;
            }
            else
            {
                parentNode = Nodes[0];
            }
            
            parentNode.Nodes.Add(d_cur.Node);
            parentNode.ExpandAll();
            SelectedNode = d_cur.Node;
        }

        void AddItems<T>(IEnumerable<T> items, TreeNode rootNode) where T: ITreeItem
        {
            AddItems<T>(items, 0, rootNode);
        }
        
        void AddItems<T>(IEnumerable<T> items, int parent, TreeNode rootNode) where T: ITreeItem
        {
            foreach (T item in items.Where(g => g.Parent_Id.GetValueOrDefault() == parent))
            {
                int c = GetCountItems(item);
                TreeNode n = rootNode.Nodes.Add(countData ? string.Format("{0} ({1})", item.Name, c) : item.Name);
                nodes.Add(new NodeData(item, n, c));
                AddItems(items, item.Id, n);
            }
        }
        
        int GetCountItems(ITreeItem item)
        {
            if (CountItems != null)
            {
                CountItemsEventArgs e = new CountItemsEventArgs(item);
                CountItems(this, e);
                return e.CountItems;
            }
            
            return 0;
        }
    }
}
