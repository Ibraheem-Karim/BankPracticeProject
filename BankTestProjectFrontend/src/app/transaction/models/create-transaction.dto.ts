export interface CreateTransactionDto {
  fromAccountNumber: string;
  toAccountNumber: string;
  amount: number;
  transactionType: string;
  description?: string;
}
