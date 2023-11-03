"use client";

import Image from "next/image";
import Link from "next/link";
import { Navbar, Footer, Table } from "flowbite-react";

export default function Home() {
  return (
    <main className="flex min-h-screen flex-col items-center justify-between p-24">
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
          <Navbar.Link href="#">Novo Cadastro</Navbar.Link>
        </Navbar.Collapse>
      </Navbar>
      <div className="z-10 max-w-5xl w-full items-center justify-between font-mono text-sm lg:flex"></div>

      <div className=" items-start">
        <Table striped>
          <Table.Head>
            <Table.HeadCell>Nome</Table.HeadCell>
            <Table.HeadCell>Email</Table.HeadCell>
            <Table.HeadCell>Data de Nascimento</Table.HeadCell>
            <Table.HeadCell>Cep</Table.HeadCell>
            <Table.HeadCell>Logradouro</Table.HeadCell>
            <Table.HeadCell>Complemento</Table.HeadCell>
            <Table.HeadCell>Bairro</Table.HeadCell>
            <Table.HeadCell>Localidade</Table.HeadCell>
            <Table.HeadCell>UF</Table.HeadCell>
            <Table.HeadCell>IBGE</Table.HeadCell>
            <Table.HeadCell>GIA</Table.HeadCell>
            <Table.HeadCell>DDD</Table.HeadCell>
            <Table.HeadCell>SIAFI</Table.HeadCell>
          </Table.Head>
          <Table.Body className="divide-y">
            <Table.Row className="bg-white dark:border-gray-700 dark:bg-gray-800">
              <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                Microsoft Surface Pro
              </Table.Cell>
              <Table.Cell>White</Table.Cell>
              <Table.Cell>Laptop PC</Table.Cell>
              <Table.Cell>$1999</Table.Cell>
              <Table.Cell>$1999</Table.Cell>
              <Table.Cell>$1999</Table.Cell>
              <Table.Cell>$1999</Table.Cell>
              <Table.Cell>$1999</Table.Cell>
              <Table.Cell>$1999</Table.Cell>
              <Table.Cell>$1999</Table.Cell>
              <Table.Cell>$1999</Table.Cell>
              <Table.Cell>$1999</Table.Cell>
              <Table.Cell>
                <a
                  href="#"
                  className="font-medium text-cyan-600 hover:underline dark:text-cyan-500"
                >
                  Edit
                </a>
              </Table.Cell>
            </Table.Row>
          </Table.Body>
        </Table>
      </div>

      <Footer container>
        <Footer.Copyright href="#" by="NEXT JS" year={2022} />
        <Footer.LinkGroup>
          <Footer.Link href="https://github.com/adryanleao">Git Hub</Footer.Link>
          <Footer.Link href="https://www.linkedin.com/in/adryanleao/">Linkedin</Footer.Link>
        </Footer.LinkGroup>
      </Footer>
    </main>
  );
}
