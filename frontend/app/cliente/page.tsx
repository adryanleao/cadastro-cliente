"use client";

import { Label, TextInput, Button } from "flowbite-react";
import React, { useState, FormEvent } from "react";
import { PATHS } from "../constants";
import { useRouter } from "next/navigation";
import { SubmitHandler, Controller, useForm } from 'react-hook-form';
import { Form, pageSchema } from '../_helper/schemes';
import { zodResolver } from '@hookform/resolvers/zod';

export default function Page() {

    const {
        control,
        handleSubmit,
        watch,
        setValue,
        formState: { isValid, errors }
      } = useForm<Form>({
        defaultValues: {
          is_month: undefined,
          area: '',
          manager: ''
        },
        resolver: zodResolver(pageSchema)
      });
  const router = useRouter();
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [error, setError] = useState<string | null>(null)


  const onSubmit: SubmitHandler<Form> = async (form) => {
    setIsLoading(true)
    setError(null)
console.log("ok");
    try {
      //const formData = new FormData(event.currentTarget);
      const formData = JSON.stringify(form);
      const response = await fetch(`${PATHS.API_URL}/api/clientes`, {
        method: "POST",
        body: formData,
      });

      if (!response.ok) {
        throw new Error('Erro ao enviar a solicitacao de cadastro')
      }

      const data = await response.json();

      const message = `A solicitacao de cadastro foi enviada.`;
    } catch (error) {
    } finally {
      setIsLoading(false); // Set loading to false when the request completes
    }
  }

  return (
    <div className="bg-white rounded-lg">
        {error && <div className="p-4" style={{ color: 'red' }}>{error}</div>}
      <form onSubmit={handleSubmit(onSubmit)}>
        <div className="grid grid-flow-col justify-stretch space-x-4 p-4">
          <div>
            <div className="mb-2 block">
              <Label htmlFor="nome" value="Nome" />
            </div>
            <Controller
                      name="nature"
                      control={control}
                      render={({ field }) => (
                        <TextInput
                          value={field.value ?? ''}
                        //   labelName="Natureza *"
                          className="col-span-1 md:col-span-2 min-[1153px]:col-span-3"
                          
                        />
                      )}
                    />
            {/* <TextInput id="nome" type="text" sizing="md" /> */}
          </div>
          <div>
            <div className="mb-2 block">
              <Label htmlFor="nome" value="E-mail" />
            </div>
            <TextInput id="nome" type="text" sizing="md" />
          </div>
          <div>
            <div className="mb-2 block">
              <Label htmlFor="dataNascimento" value="Data de Nascimento" />
            </div>
            <TextInput id="dataNascimento" type="text" sizing="md" />
          </div>
        </div>
        <div className="grid grid-flow-col justify-stretch space-x-4 p-4">
          <div>
            <div className="mb-2 block">
              <Label htmlFor="cep" value="CEP" />
            </div>
            <TextInput id="cep" type="text" sizing="md" />
          </div>
          <div>
            <div className="mb-2 block">
              <Label htmlFor="logradouro" value="Logradouro" />
            </div>
            <TextInput id="logradouro" type="text" sizing="md" disabled />
          </div>
          <div>
            <div className="mb-2 block">
              <Label htmlFor="complemento" value="Complemento" />
            </div>
            <TextInput id="complemento" type="text" sizing="md" disabled />
          </div>
        </div>
        <div className="grid grid-flow-col justify-stretch space-x-4 p-4">
          <div>
            <div className="mb-2 block">
              <Label htmlFor="bairro" value="Bairro" />
            </div>
            <TextInput id="bairro" type="text" sizing="md" disabled />
          </div>
          <div>
            <div className="mb-2 block">
              <Label htmlFor="localidade" value="Localidade" />
            </div>
            <TextInput id="localidade" type="text" sizing="md" disabled />
          </div>
          <div>
            <div className="mb-2 block">
              <Label htmlFor="uf" value="UF" />
            </div>
            <TextInput id="uf" type="text" sizing="md" disabled />
          </div>
        </div>
        <div className="grid grid-flow-col justify-stretch space-x-4 p-4">
          <div>
            <div className="mb-2 block">
              <Label htmlFor="ibge" value="IBGE" />
            </div>
            <TextInput id="ibge" type="text" sizing="md" disabled />
          </div>
          <div>
            <div className="mb-2 block">
              <Label htmlFor="gia" value="GIA" />
            </div>
            <TextInput id="gia" type="text" sizing="md" disabled />
          </div>
          <div>
            <div className="mb-2 block">
              <Label htmlFor="ddd" value="DDD" />
            </div>
            <TextInput id="ddd" type="text" sizing="md" disabled />
          </div>
        </div>
        <div className="grid grid-cols-3  justify-stretch  p-4">
          <div>
            <div className="mb-2 block">
              <Label htmlFor="siafi" value="SIAFI" />
            </div>
            <TextInput id="siafi" type="text" sizing="md" disabled />
          </div>
          <div className=""></div>
          <div>
            <Button color="blue" type="submit" disabled={isLoading}>
            {isLoading ? 'Enviando...' : 'Cadastrar'}
            </Button>
          </div>
        </div>
      </form>
    </div>
  );
}
