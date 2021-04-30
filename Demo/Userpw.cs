using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

public static class Userpw
{

	public static byte[] PBKDF2_newhash(string password, int sn, int pn, int n)
	{
		byte[] salt;
		new RNGCryptoServiceProvider().GetBytes(salt = new byte[sn]);
		var pbkdf2 = new Rfc2898DeriveBytes(password, salt, n);
		byte[] pwhash = pbkdf2.GetBytes(pn);
		byte[] h = new byte[sn+pn];
		Array.Copy(salt, 0, h, 0, sn);
		Array.Copy(pwhash, 0, h, sn, pn);
		return h;
	}


	public static bool PBKDF2_verify(byte[] pwhash, string password, int sn, int pn, int n)
	{
		byte[] salt16 = new byte[sn];
		Array.Copy(pwhash, 0, salt16, 0, sn);
		var pbkdf2 = new Rfc2898DeriveBytes(password, salt16, n);
		byte[] hash = pbkdf2.GetBytes(pn);
		for (int i = 0; i < pn; i++)
		{
			if (pwhash[i+sn] != hash[i])
			{
				return false;
			}
		}
		return true;
	}






}