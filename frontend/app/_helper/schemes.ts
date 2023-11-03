import { z } from 'zod';

import { currencyToNumber } from './currency';

const nonEmptyValidationSchema = z.string().refine(
  (value) => {
    return value.trim() !== '';
  },
  {
    message: 'Campo obrigatório'
  }
);

const recoveredSchema = z.object({
  recovered_value: nonEmptyValidationSchema,
  date_recovered: z.date()
});

const formSchema = z.object({
  process: nonEmptyValidationSchema,
  risk: nonEmptyValidationSchema,
  occurrence_loss: z.date(),
  recognition_loss: z.date(),
  company: nonEmptyValidationSchema,
  nature: nonEmptyValidationSchema,
  cause_loss: nonEmptyValidationSchema,
  category: nonEmptyValidationSchema,
  judicial_origin: nonEmptyValidationSchema,
  loss_value: nonEmptyValidationSchema,
  is_recovery: z.boolean(),
  description: z
    .string()
    .min(1)
    .max(500)
    .refine(
      (value) => {
        return value.trim() !== '';
      },
      {
        message: 'Campo obrigatório'
      }
    ),
  root_cause: z
    .string()
    .min(1)
    .max(1000)
    .refine(
      (value) => {
        return value.trim() !== '';
      },
      {
        message: 'Campo obrigatório'
      }
    ),
  actions_taken: z
    .string()
    .min(1)
    .max(1000)
    .refine(
      (value) => {
        return value.trim() !== '';
      },
      {
        message: 'Campo obrigatório'
      }
    )
});

const _pageSchema = z
  .object({
    is_month: z.boolean(),
    area: nonEmptyValidationSchema,
    manager: nonEmptyValidationSchema
  })
  .merge(formSchema.partial())
  .merge(recoveredSchema.partial());

export const pageSchema = _pageSchema.superRefine((data, ctx) => {
  if (data.is_month) {
    if (
      data.occurrence_loss &&
      data.recognition_loss &&
      data.occurrence_loss > data.recognition_loss
    ) {
      ctx.addIssue({
        code: z.ZodIssueCode.custom,
        path: ['recognition_loss'],
        message: 'data de reconhecimento não pode ser menor que de ocorrência',
        fatal: true
      });

      return z.NEVER;
    }

    const result = formSchema.safeParse(data);

    if (!result.success) {
      result.error.errors.forEach((issue) => ctx.addIssue(issue));

      return z.NEVER;
    }

    if (data.is_recovery) {
      const resultRecovered = recoveredSchema.safeParse(data);

      if (!resultRecovered.success) {
        resultRecovered.error.errors.forEach((issue) => ctx.addIssue(issue));

        return z.NEVER;
      }

      if (
        data.occurrence_loss &&
        data.date_recovered &&
        data.occurrence_loss > data.date_recovered
      ) {
        ctx.addIssue({
          code: z.ZodIssueCode.custom,
          path: ['date_recovered'],
          message: 'data de recuperação não pode ser menor que de ocorrência',
          fatal: true
        });

        return z.NEVER;
      }

      if (
        data.loss_value &&
        data.recovered_value &&
        currencyToNumber(data.loss_value) <
          currencyToNumber(data.recovered_value)
      ) {
        ctx.addIssue({
          code: z.ZodIssueCode.custom,
          path: ['recovered_value'],
          message: 'valor de recuperação deve ser menor que o da perda'
        });
      }
    }
  }
});

const _pagesSchemaEnum = _pageSchema.keyof();
export type FormKeys = z.infer<typeof _pagesSchemaEnum>;
export type Form = z.infer<typeof pageSchema>;

function makeOptionalPropsNullable<Schema extends z.AnyZodObject>(
  schema: Schema
) {
  const entries = Object.entries(schema.shape) as [
    keyof Schema['shape'],
    z.ZodTypeAny
  ][];
  const newProps = entries.reduce(
    (acc, [key, value]) => {
      acc[key] =
        value instanceof z.ZodOptional ? value.unwrap().nullable() : value;
      return acc;
    },
    {} as {
      [key in keyof Schema['shape']]: Schema['shape'][key] extends z.ZodOptional<
        infer T
      >
        ? z.ZodNullable<T>
        : Schema['shape'][key];
    }
  );
  return z.object(newProps);
}

const identifierSchema = z.object({
  _id: z.string(),
  id: z.string(),
  date: z.date(),
  area_id: z.string(),
  manager: z.string(),
  requester: z.string()
});

const responseFormSchema = makeOptionalPropsNullable(
  _pageSchema.merge(identifierSchema)
);

export type ResponseForm = z.infer<typeof responseFormSchema>;
