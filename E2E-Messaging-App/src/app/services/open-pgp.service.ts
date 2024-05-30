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
}
