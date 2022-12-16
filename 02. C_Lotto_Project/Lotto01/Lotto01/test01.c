#include<stdio.h>
#include<stdlib.h>
#include<time.h>

// ��ũ�� ��� ����
#define SIZE 6

// �������� ����
//void rand_num(int n);
//int odd_check(int snum[], int size);
//int even_check(int snum[], int size);
//int lotto[SIZE];

void bubbleSort(int arr[], int size) // �������� ���� (��������)
{
	int temp = 0;
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			if (arr[i] < arr[j])
			{
				temp = arr[i];
				arr[i] = arr[j];
				arr[j] = temp;
			}
		}
	}
}

int odd_check(int snum[], int size) // ��� Ȧ������ �Ǻ��ϴ� �Լ�(���� 2�� ������ �� '1'�̶�� Ȧ��)
{
	int check[SIZE];
	for (int i = 0; i < size; i++)
	{
		check[i] = (snum[i] % 1);
	}
	if (check[0] == 1 && check[1] == 1 && check[2] == 1 && check[3] == 1 && check[4] == 1 && check[5] == 1)
		return 1;
	else
		return 0;
}

int even_check(int snum[], int size) // ��� ¦������ �Ǻ��ϴ� �Լ�(���� 2�� ������ �� '0'�̶�� ¦��)
{
	int check[SIZE];
	for (int i = 0; i < size; i++)
	{
		check[i] = (snum[i] % 2);
	}
	if (check[0] == 0 && check[1] == 0 && check[2] == 0 && check[3] == 0 && check[4] == 0 && check[5] == 0)
		return 1;
	else
		return 0;
}

void rand_num(int n)
{
	int odd, even;
	int num[6]; // ���� ������ �ζǹ�ȣ
	int lotto[6] = { 0 }; // �񱳵� �ζǹ�ȣ
	srand(time(NULL));

	for (int j = 0; j < n; j++)
	{
		odd = 0;
		even = 0;
		for (int i = 0; i < SIZE; i++)
		{
			num[i] = (rand() % 45 + 1); 
			if (num[i] != lotto[0] && num[i] != lotto[1] && num[i] != lotto[2] &&
				num[i] != lotto[3] && num[i] != lotto[4] && num[i] != lotto[5])
			{ // ���� �ٿ� ���� ���ڰ� �ִ��� �迭 ��ü�� ��
				lotto[i] = num[i]; // ��ġ���� ������ ����
			}
			else
			{
				i--;
			}
		}

		bubbleSort(lotto, 6);
		odd = odd_check(lotto, SIZE);
		even = even_check(lotto, SIZE);

		if (odd == 1 || even == 1) // üũ �� �ϳ��� 1�� ���� ��� ��ȣ �����
		{
			j--;
		}
		else
		{
			printf("%2d��Ʈ : ", j+1);
			for (int i = 0; i < 6; i++) // ��ȣ ���
			{
				printf("%2d ", lotto[i]);
			}
			printf("\n");
		}
		for (int i = 0; i < 6; i++)
		{
			lotto[i] = 0;
		}
	}
	return 0;
}

int main()
{
	int n;
	printf("��ȣ�� �� ��Ʈ ����ұ��? ");
	scanf_s("%d", &n);
	rand_num(n); // ��ȣ ����, ��� �Լ� ȣ��

	/*
	int lotto[SIZE];
	int loto[6] = { 0 };
	int i, j, n;
	srand(time(NULL));	

	for (i = 0; i < SIZE; i++)
	{
		lotto[i] = (rand() % 45 + 1);
		for (j = 0; j < i; j++)
		{
			if (lotto[i] == lotto[j])
			{
				i--;
			}
		}
	}
	bubbleSort(lotto, SIZE);

	for (i = 0; i < SIZE; i++)
	{
		printf("��÷��ȣ : %d\n", lotto[i]);
	}
	*/
	return 0;
}