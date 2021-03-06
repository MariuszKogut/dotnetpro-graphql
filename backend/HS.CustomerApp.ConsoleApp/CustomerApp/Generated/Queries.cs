﻿using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace HS.CustomerApp.ConsoleApp
{
    public class Queries
        : IDocument
    {
        private readonly byte[] _hashName = new byte[]
        {
            109,
            100,
            53,
            72,
            97,
            115,
            104
        };
        private readonly byte[] _hash = new byte[]
        {
            113,
            48,
            107,
            118,
            66,
            118,
            99,
            97,
            109,
            52,
            118,
            50,
            81,
            98,
            81,
            77,
            111,
            90,
            87,
            76,
            104,
            81,
            61,
            61
        };
        private readonly byte[] _content = new byte[]
        {
            113,
            117,
            101,
            114,
            121,
            32,
            71,
            101,
            116,
            67,
            117,
            115,
            116,
            111,
            109,
            101,
            114,
            115,
            32,
            123,
            32,
            99,
            117,
            115,
            116,
            111,
            109,
            101,
            114,
            115,
            32,
            123,
            32,
            95,
            95,
            116,
            121,
            112,
            101,
            110,
            97,
            109,
            101,
            32,
            105,
            100,
            32,
            110,
            97,
            109,
            101,
            32,
            108,
            111,
            99,
            97,
            116,
            105,
            111,
            110,
            32,
            125,
            32,
            125,
            32,
            113,
            117,
            101,
            114,
            121,
            32,
            71,
            101,
            116,
            67,
            117,
            115,
            116,
            111,
            109,
            101,
            114,
            40,
            36,
            105,
            100,
            58,
            32,
            73,
            110,
            116,
            33,
            41,
            32,
            123,
            32,
            99,
            117,
            115,
            116,
            111,
            109,
            101,
            114,
            40,
            105,
            100,
            58,
            32,
            36,
            105,
            100,
            41,
            32,
            123,
            32,
            95,
            95,
            116,
            121,
            112,
            101,
            110,
            97,
            109,
            101,
            32,
            105,
            100,
            32,
            110,
            97,
            109,
            101,
            32,
            108,
            111,
            99,
            97,
            116,
            105,
            111,
            110,
            32,
            125,
            32,
            125,
            32,
            109,
            117,
            116,
            97,
            116,
            105,
            111,
            110,
            32,
            67,
            114,
            101,
            97,
            116,
            101,
            67,
            117,
            115,
            116,
            111,
            109,
            101,
            114,
            40,
            36,
            99,
            117,
            115,
            116,
            111,
            109,
            101,
            114,
            58,
            32,
            67,
            114,
            101,
            97,
            116,
            101,
            67,
            117,
            115,
            116,
            111,
            109,
            101,
            114,
            77,
            111,
            100,
            101,
            108,
            73,
            110,
            112,
            117,
            116,
            33,
            41,
            32,
            123,
            32,
            99,
            114,
            101,
            97,
            116,
            101,
            67,
            117,
            115,
            116,
            111,
            109,
            101,
            114,
            40,
            105,
            110,
            112,
            117,
            116,
            58,
            32,
            36,
            99,
            117,
            115,
            116,
            111,
            109,
            101,
            114,
            41,
            32,
            125
        };

        public ReadOnlySpan<byte> HashName => _hashName;

        public ReadOnlySpan<byte> Hash => _hash;

        public ReadOnlySpan<byte> Content => _content;

        public static Queries Default { get; } = new Queries();

        public override string ToString() => 
            @"query GetCustomers {
              customers {
                id
                name
                location
              }
            }
            
            query GetCustomer($id: Int!) {
              customer(id: $id) {
                id
                name
                location
              }
            }
            
            mutation CreateCustomer($customer: CreateCustomerModelInput!) {
              createCustomer(input: $customer)
            }";
    }
}
