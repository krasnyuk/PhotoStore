<<<<<<< HEAD
﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PhotosStore.Domain.Entities
{
    //класс корзины заказов
    public class Cart
    {
        private readonly List<CartLine> _lineCollection = new List<CartLine>(); //коллекция содержимого корзины
        //добавить новый итем
        public void AddItem(PhotoTechnique technique, int quantity)
        {
            //найти в коллекции объект с ID пришедшего параметра
            CartLine line = _lineCollection.FirstOrDefault(g => g.PhotoTechnique.PhotoTechniqueId == technique.PhotoTechniqueId);

            if (line == null) //если объект новый
            {
                _lineCollection.Add(new CartLine
                {
                    PhotoTechnique = technique,
                    Quantity = quantity
                });
            }
            else //если такой уже есть квеличить количество
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(PhotoTechnique technique)
        {
            _lineCollection.RemoveAll(l => l.PhotoTechnique.PhotoTechniqueId == technique.PhotoTechniqueId);
        }

        public decimal ComputeTotalValue()
        {
            return _lineCollection.Sum(e => e.PhotoTechnique.Price * e.Quantity);
        }
        public void Clear()
        {
            _lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return _lineCollection; }
        }
    }

    public class CartLine
    {
        public PhotoTechnique PhotoTechnique { get; set; }
        public int Quantity { get; set; }
    }
}

=======
﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PhotosStore.Domain.Entities
{
   public class Cart
    {
        private readonly List<CartLine> _lineCollection = new List<CartLine>();
       
        public void AddItem(PhotoTechnique technique, int quantity)
        {
            CartLine line = _lineCollection.FirstOrDefault(g => g.PhotoTechnique.PhotoTechniqueId == technique.PhotoTechniqueId);

            if (line == null)
            {
                _lineCollection.Add(new CartLine
                {
                    PhotoTechnique = technique,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(PhotoTechnique technique)
        {
            _lineCollection.RemoveAll(l => l.PhotoTechnique.PhotoTechniqueId == technique.PhotoTechniqueId);
        }

        public decimal ComputeTotalValue()
        {
            return _lineCollection.Sum(e => e.PhotoTechnique.Price * e.Quantity);
        }
        public void Clear()
        {
            _lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return _lineCollection; }
        }
    }

    public class CartLine
    {
        public PhotoTechnique PhotoTechnique { get; set; }
        public int Quantity { get; set; }
    }
}

>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6
