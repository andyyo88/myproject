using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LadyBelle.Function;
using System.Text;
using ADODB;
using System.Data;

namespace LadyBelle.Function
{
    public class Product
    {
        connection conn = new connection();
        public DataTable getProductList(string id, string where, Connection cn)
        {
            string sql = "getProductList_rd '" + id + "','" + where + "'";
            return conn.ExecuteScalar(sql,cn);
        }

        public void modifyProduct(string text, string text1, string text2, string categoryID, string text3,string getUser, Connection cn)
        {
            string sql = "modifyProduct_rd '" + text + "','" + text1 + "','" + text2 + "','" + categoryID + "','" + getUser + "','" + DateTime.Now + "','" + text3 + "'";
            conn.ExecuteQuery(sql, cn);
        }
        public string GetImageURL(string path)
        {
            string fullpath = path;
            if (path.Equals(""))
                fullpath = "~/images/defaultImage.jpg";
            return fullpath;
        }

        public DataTable getProductDetList(string ID, string where, Connection cn)
        {
            string sql = "getProductDetList_rd '" + ID + "','" + where + "'";
            return conn.ExecuteScalar(sql, cn);
        }
        public void modifyProductDet(string productID,string ProductDetCode,string ProductDetName,string Price,string Status,string Weight,string Size, string Satuan,string Diskon,string ProductDetID, Connection cn)
        {
            string sql = "modifyProductDet_rd '" + productID + "','" + ProductDetCode + "','" + ProductDetName + "','" + Price + "','" + Status + "','" + Weight + "','" + Size + "','" + Satuan + "','" + Diskon + "','" + ProductDetID + "'";
            conn.ExecuteQuery(sql, cn);
        }

        public DataTable getProductImgList(string ID, string where, Connection cn)
        {
            string sql = "getProductImgList_rd '" + ID + "','" + where + "'";
            return conn.ExecuteScalar(sql, cn);
        }

        public void modifyProductImg(string productDetID, string ImageURL, string ImageOrder, Connection cn)
        {
            string sql = "modifyProductImg_rd '" + productDetID + "','" + ImageURL + "','" + ImageOrder + "'";
            conn.ExecuteQuery(sql, cn);
        }

        public void changeOrderImage(string productDetID, string Order, string URL, Connection cn)
        {
            string sql = "changeOrderImage_rd '" + productDetID + "','" + Order + "','" + URL + "'";
            conn.ExecuteQuery(sql, cn);

        }

        public int getStockCount(string productDetID, Connection cn)
        {
            string sql = "getStockCount_rd '" + productDetID + "'";
            DataTable dtProd = conn.ExecuteScalar(sql, cn);
            return int.Parse(dtProd.Rows[0].ItemArray[0].ToString());
        }

        public void modifyProductStock(string productdetid,string slong,string sshort,string date,string status,string note,string userid,string lastupdate,Connection cn)
        {
            string sql = "modifyProductStock_rd '" + productdetid + "','" + slong + "','" + sshort + "','" + date + "','" + status + "','" + note + "','" + userid + "','" + lastupdate + "'";
            conn.ExecuteQuery(sql, cn);
         }
    }
}