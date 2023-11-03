"use client";

import Image from "next/image";
import Link from "next/link";
import { Navbar, Footer, Table } from "flowbite-react";
import useSWR from 'swr';
import {
  ResponseCliente
} from './@types/api';
import { Skeleton } from "./components";

async function getClientes(params: { url: string }) {
  const response = await fetch(`${params.url}`);
  const json: Array<ResponseCliente> = await response.json();
  return json;
}

export default function Home() {

  const { data: clientes, isLoading: isLoadingClientes } = useSWR(() => {
    return {
      url: 'http://localhost:2000/api/clientes'
    };
  }, getClientes);

  const renderClientes = () => {
    if (isLoadingClientes) {
      return Array.from({ length: 4 }, (_, v) => v + 1).map((i) => (
        <Table.Row key={`table-column-skeleton-${i}`}>
          <Table.Cell>
            <Skeleton height={20} width={80} />
          </Table.Cell>
          <Table.Cell>
            <Skeleton height={20} width={80} />
          </Table.Cell>
          <Table.Cell>
            <Skeleton height={20} width={80} />
          </Table.Cell>
          <Table.Cell>
            <Skeleton height={20} width={80} />
          </Table.Cell>
          <Table.Cell>
            <Skeleton height={20} width={80} />
          </Table.Cell>
          <Table.Cell>
            <Skeleton height={20} width={80} />
          </Table.Cell>
          <Table.Cell>
            <Skeleton height={20} width={80} />
          </Table.Cell>
          <Table.Cell>
            <Skeleton height={20} width={80} />
          </Table.Cell>
          <Table.Cell>
            <Skeleton height={20} width={80} />
          </Table.Cell>
          <Table.Cell>
            <Skeleton height={20} width={80} />
          </Table.Cell>
          <Table.Cell>
            <Skeleton height={20} width={80} />
          </Table.Cell>
          <Table.Cell>
            <Skeleton height={20} width={80} />
          </Table.Cell>
          <Table.Cell>
            <Skeleton height={20} width={80} />
          </Table.Cell>
        </Table.Row>
      ));
    }
    if (!clientes) {
      return null;
    }
    return clientes.map((cliente, index) => (
      <Table.Row key={`table-column-${cliente.id}-${String(index)}`}>
        <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                {cliente.nome}
              </Table.Cell>
              <Table.Cell>{cliente.email}</Table.Cell>
              <Table.Cell>{cliente.dataNascimento}</Table.Cell>
              <Table.Cell>{cliente.cep}</Table.Cell>
              <Table.Cell>{cliente.logradouro}</Table.Cell>
              <Table.Cell>{cliente.complemento}</Table.Cell>
              <Table.Cell>{cliente.bairro}</Table.Cell>
              <Table.Cell>{cliente.localidade}</Table.Cell>
              <Table.Cell>{cliente.uf}</Table.Cell>
              <Table.Cell>{cliente.ibge}</Table.Cell>
              <Table.Cell>{cliente.gia}</Table.Cell>
              <Table.Cell>{cliente.ddd}</Table.Cell>
              <Table.Cell>{cliente.siafi}</Table.Cell>
              <Table.Cell>
                <a
                  href="#"
                  className="font-medium text-cyan-600 hover:underline dark:text-cyan-500"
                >
                  Editar
                </a>
              </Table.Cell>
            </Table.Row>
    ));
  };

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
            <Table.HeadCell><span className="font-medium text-cyan-600">
              AÇÃO
              </span></Table.HeadCell>
          </Table.Head>
          <Table.Body className="divide-y">
            {renderClientes()}
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
