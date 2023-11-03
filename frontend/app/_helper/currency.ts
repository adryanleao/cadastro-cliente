import { BeforeMaskedStateChangeStates, InputState } from 'react-input-mask';

/**
 * The formatCurrency function formats a number as a currency value in Brazilian
 * Real (BRL) format.
 * @param {number} value - The value parameter is a number that represents the
 * currency value that you want to format.
 * @returns a formatted currency value in Brazilian Real (BRL) format.
 */
export function formatCurrency(value: number) {
  return new Intl.NumberFormat('pt-BR', {
    style: 'currency',
    currency: 'BRL'
  }).format(value);
}

/**
 * Format to Brazilian currency
 *
 * The `maskToCurrency` function takes an input value and formats it as a currency
 * value with the currency symbol "R$".
 * @param {BeforeMaskedStateChangeStates}  - - `nextState`: The next state of the
 * input field, which includes the current value and selection (start and end
 * positions).
 * @returns an object of type `InputState`.
 */
export const maskToCurrency = ({
  nextState
}: BeforeMaskedStateChangeStates): InputState => {
  const { value } = nextState || {};

  let amountFormatted = value?.replace?.(/\D/g, '');
  amountFormatted = amountFormatted?.replace?.(/^0+/g, '');

  if (amountFormatted?.length === 2) {
    return {
      ...nextState,
      value: `R$ ${amountFormatted}`,
      selection: {
        start: amountFormatted.length + 3,
        end: amountFormatted.length + 3
      }
    };
  }

  const amountFormattedWithComma = amountFormatted?.replace?.(
    /(?=\d{2})(\d{2})$/,
    ',$1'
  );
  const amountFormattedWithDot = amountFormattedWithComma?.replace?.(
    /(\d)(?=(\d{3})+(?!\d))/g,
    '$1.'
  );

  if (amountFormattedWithDot) {
    return {
      ...nextState,
      value: `R$ ${amountFormattedWithDot}`,
      selection: {
        start: amountFormattedWithDot.length + 3,
        end: amountFormattedWithDot.length + 3
      }
    };
  }

  return nextState;
};

/**
 * The currencyToNumber function takes a string representing a currency value and
 * returns the equivalent number value.
 * @param {string} currency - The `currency` parameter is a string representing a
 * currency value.
 * @returns a number.
 */
export function currencyToNumber(currency: string): number {
  const value = currency.replace(/\D/gi, '');
  const parsedValue = parseInt(value);

  if (isNaN(parsedValue)) {
    return 0;
  }

  return parsedValue / 100;
}
