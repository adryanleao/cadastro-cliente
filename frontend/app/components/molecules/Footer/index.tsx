"use client";

import { Footer } from "flowbite-react";

export default function FooterCustom() {
  return (
      <Footer container>
        <Footer.Copyright href="#" by="NEXT JS" year={2022} />
        <Footer.LinkGroup>
          <Footer.Link href="https://github.com/adryanleao">
            Git Hub
          </Footer.Link>
          <Footer.Link href="https://www.linkedin.com/in/adryanleao/">
            Linkedin
          </Footer.Link>
        </Footer.LinkGroup>
      </Footer>
  );
}
