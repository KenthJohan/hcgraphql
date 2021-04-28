using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

public static class Userpw
{

	private static bool cmp(ReadOnlySpan<byte> a, ReadOnlySpan<byte> b)
	{
		//https://stackoverflow.com/questions/43289/comparing-two-byte-arrays-in-net
		return a.SequenceEqual(b);
	}

	private static byte[] concat(byte[] a, byte[] b)
	{
		//https://stackoverflow.com/questions/895120/append-two-or-more-byte-arrays-in-c-sharp
		var s = new MemoryStream();
		s.Write(a, 0, a.Length);
		s.Write(b, 0, b.Length);
		return s.ToArray();
	}

	public static byte[] SHA512_make(Guid guid, string password)
	{
		byte[] buf = concat(guid.ToByteArray(), Encoding.UTF8.GetBytes(password));
		using var sha = SHA512.Create();
		byte[] hash64 = sha.ComputeHash(buf);
		return hash64;
	}


	public static bool SHA512_compare(byte[] hash, Guid guid, string password)
	{
		byte[] buf = concat(guid.ToByteArray(), Encoding.UTF8.GetBytes(password));
		using var sha = SHA512.Create();
		byte[] h = sha.ComputeHash(buf);
		return cmp(hash, h);
	}

}