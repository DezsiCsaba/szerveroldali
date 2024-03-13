using M3SuperHeroManager.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace M3SuperHeroManager.Helpers
{
    public class SuperHeroModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            SuperHero hero = new SuperHero();
            hero.Name = bindingContext.ValueProvider.GetValue("name").FirstValue;
            hero.Power = int.Parse(bindingContext.ValueProvider.GetValue("power").FirstValue);
            hero.Side = (HeroSide)int.Parse(bindingContext.ValueProvider.GetValue("side").FirstValue);
            hero.Alien = bool.Parse(bindingContext.ValueProvider.GetValue("alien").FirstValue);

            if (bindingContext.HttpContext.Request.Form.Files.Count > 0)
            {
                var file = bindingContext.HttpContext.Request.Form.Files[0];
                using (var stream = file.OpenReadStream())
                {
                    byte[] buffer = new byte[file.Length];
                    stream.Read(buffer, 0, (int)file.Length);
                    string filename = hero.Id + "." + file.FileName.Split('.')[1];
                    hero.ImageFileName = filename;
                    //db módszer
                    hero.Data = buffer;
                    hero.ContentType = file.ContentType;
                }
            }
            
            bindingContext.Result = ModelBindingResult.Success(hero);
            return Task.CompletedTask;

        }
    }
}
