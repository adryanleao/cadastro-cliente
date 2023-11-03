'use client';
import React from 'react';
import { Navbar } from "flowbite-react";
import Image from 'next/image';
import Link from "next/link";
import { PATHS } from '@/app/constants';


export default function Header() {
  return (
    <Navbar fluid rounded className="w-full items-center">
        <Navbar.Brand as={Link} href="https://flowbite-react.com">
          <img
            src="https://avatars.githubusercontent.com/u/14956372?v=4"
            className="mr-3 h-6 sm:h-9"
            alt="Flowbite React Logo"
          />
          <span className="self-center whitespace-nowrap text-xl text-gray-800 font-semibold dark:text-white">
            Desafio - Cadastro Cliente
          </span>
        </Navbar.Brand>
        <Navbar.Toggle />
        <Navbar.Collapse>
          <Navbar.Link href="#" active>
            Home
          </Navbar.Link>
          <Navbar.Link href={`${PATHS.REGISTER}`}>Novo Cadastro</Navbar.Link>
        </Navbar.Collapse>
      </Navbar>
  );
}
