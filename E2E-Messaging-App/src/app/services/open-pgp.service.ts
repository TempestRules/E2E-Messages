import { Injectable } from '@angular/core';
import * as openpgp from 'openpgp';
import { KeyPair } from '../models/keypair';

@Injectable({
  providedIn: 'root'
})
export class OpenPGPService {

  constructor() { }

  public async generateKeyPair(username: string, password: string): Promise<KeyPair> {
    const { privateKey, publicKey } = await openpgp.generateKey({
      type: 'ecc',
      curve: 'curve25519',
      userIDs: [{ name: username }],
      passphrase: password,
      format: 'armored'
    });

    return { privateKey, publicKey };
  }

  public async encryptMessage(message: string, publicKeysArmored: string[]): Promise<openpgp.WebStream<string>> {
      const publicKeys = await Promise.all(publicKeysArmored.map(armoredKey => openpgp.readKey({ armoredKey })));

      const pgpMessage = await openpgp.createMessage({ text: message });
      const encrypted = await openpgp.encrypt({
          message: pgpMessage,
          encryptionKeys: publicKeys,
          //signingKeys: privateKey // optional
      });

      return encrypted;
  }
}
