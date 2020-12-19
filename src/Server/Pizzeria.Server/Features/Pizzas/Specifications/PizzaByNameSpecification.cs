namespace Pizzeria.Server.Features.Pizzas.Specifications
{
    using System;
    using System.Linq.Expressions;
    using Data.Models;
    using Infrastructure.Common;

    internal class PizzaByNameSpecification : Specification<Pizza>
    {
        private readonly string name;

        internal PizzaByNameSpecification(string name) => this.name = name;

        protected override bool Include => this.name != null;

        public override Expression<Func<Pizza, bool>> ToExpression()
            => product => product.Name.ToLower().Contains(this.name.ToLower());
    }
}
