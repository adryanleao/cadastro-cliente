
import {
  ResponseCliente,
  GUID
} from '@/app/@types/api';

interface Props {
    params: {
      id: GUID;
    };
  }
export default function Page({ params }: Props) {
    return (
      <ul className="list">
        <li>Contato</li>
      </ul>
    );
  }
  