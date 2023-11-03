"use client";

import {Table } from "flowbite-react";
import useSWR from 'swr';
import {
  ResponseCliente,
  GUID
} from './@types/api';
import { Footer, Skeleton } from "./components";
import { useRouter } from 'next/navigation';
import { PATHS } from "./constants";

async function getClientes(params: { url: string }) {
  const response = await fetch(`${params.url}`);
  const json: Array<ResponseCliente> = await response.json();
  return json;
}

export default function Home() {
  const router = useRouter();

  const { data: clientes, isLoading: isLoadingClientes } = useSWR(() => {
    return {
      url: `${PATHS.API_URL}/api/clientes`
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
                  className="font-medium text-cyan-600 hover:underline dark:text-cyan-500"
                  onClick={() => {
                    handleOpenItem(cliente.id);
                  }}
                >
                  Editar
                </a>
              </Table.Cell>
            </Table.Row>
    ));
  };

  const handleOpenItem = (id: GUID) => {
    router.push(`/${id}`);
  };

  return (
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
  );
}
