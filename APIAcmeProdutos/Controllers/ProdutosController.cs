using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APIAcmeProdutos.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using Microsoft.Azure.NotificationHubs;

namespace APIAcmeProdutos.Controllers
{
    public class ProdutosController : ApiController
    {
        private APIAcmeProdutosContext db = new APIAcmeProdutosContext();

        //const string FCM_ENDERECO = "https://fcm.googleapis.com/fcm";
        //const string FCM_SERVER_KEY = "AAAAti0xGs4:APA91bFfy3RVcnkPfcMsvYbLa7gPjeAiYvt4-4MsOpqb4iAth1l6WSvRyel1W3B9059NCaP9Z7XTkhB3cg1hFlBviDearPEzfOTRCOQTt8RFmLqCo92-HTI8PKPrV9svEySpQZnpzEtH";

        const string hubName = "HubAcme";
        const string hubString = "Endpoint=sb://hubacmenamespace.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=BdYZz2ZusZ208Q5GXTQXbBh3DfHBeYAA30VhSWXYVGc=";

        // GET: api/Produtos
        public IQueryable<Produto> GetProdutos()
        {
            return db.Produtos;
        }

        // GET: api/Produtos/5
        [ResponseType(typeof(Produto))]
        public IHttpActionResult GetProduto(int id)
        {
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }

            return Ok(produto);
        }

        // PUT: api/Produtos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduto(int id, Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produto.ID)
            {
                return BadRequest();
            }

            db.Entry(produto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Produtos
        [ResponseType(typeof(Produto))]
        public IHttpActionResult PostProduto(Produto produto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Produtos.Add(produto);
            db.SaveChanges();

            SendPush();

            return CreatedAtRoute("DefaultApi", new { id = produto.ID }, produto);
        }

        public void SendPush ()
        {
            var hub = NotificationHubClient.CreateClientFromConnectionString(
                connectionString: hubString,
                notificationHubPath: hubName
                );

            var json = "{\"data\":{\"message\":\"Notification via BackEnd\"}}";

            hub.SendGcmNativeNotificationAsync(json);
        }

        // DELETE: api/Produtos/5
        [ResponseType(typeof(Produto))]
        public IHttpActionResult DeleteProduto(int id)
        {
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return NotFound();
            }

            db.Produtos.Remove(produto);
            db.SaveChanges();

            return Ok(produto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProdutoExists(int id)
        {
            return db.Produtos.Count(e => e.ID == id) > 0;
        }
    }
}