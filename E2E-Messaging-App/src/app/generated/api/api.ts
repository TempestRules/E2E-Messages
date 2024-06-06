export * from './account.service';
import { AccountService } from './account.service';
export * from './message.service';
import { MessageService } from './message.service';
export const APIS = [AccountService, MessageService];
