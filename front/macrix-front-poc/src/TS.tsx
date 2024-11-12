import '@mantine/core/styles.css';
import '@mantine/dates/styles.css'; //if using mantine date picker features
import 'mantine-react-table/styles.css'; //make sure MRT styles were imported in your app root (once)
import { useMemo, useState } from 'react';
import {
  MantineReactTable,
  type MRT_ColumnDef,
  type MRT_Row,
  type MRT_TableOptions,
  useMantineReactTable,
} from 'mantine-react-table';
import { ActionIcon, Button, Flex, Text, Tooltip } from '@mantine/core';
import { ModalsProvider, modals } from '@mantine/modals';
import { IconEdit, IconTrash } from '@tabler/icons-react';
import {
  QueryClient,
  QueryClientProvider,
  useMutation,
  useQuery,
  useQueryClient,
} from '@tanstack/react-query';
import { Person } from "./personType";
import {v4, v4 as uuidv4} from 'uuid';

const Example = () => {
  const [validationErrors, setValidationErrors] = useState<
    Record<string, string | undefined>
  >({});

  const columns = useMemo<MRT_ColumnDef<Person>[]>(
    () => [
      {
        accessorKey: 'id',
        header: 'Id',
        enableEditing: false,
        size: 80,
      },
      {
        accessorKey: 'firstName',
        header: 'First Name',
        mantineEditTextInputProps: {
          type: 'text',
          required: true,
          error: validationErrors?.firstName,
          //remove any previous validation errors when user focuses on the input
          onFocus: () =>
            setValidationErrors({
              ...validationErrors,
              firstName: undefined,
            }),
          //optionally add validation checking for onBlur or onChange
        },
      },
      {
        accessorKey: 'lastName',
        header: 'Last Name',
        mantineEditTextInputProps: {
          type: 'text',
          required: true,
          error: validationErrors?.lastName
        },
      },
      {
        accessorKey: 'streetName',
        header: 'Street Name',
        mantineEditTextInputProps: {
          type: 'text',
          required: true,
          error: validationErrors?.streetName
        },
      },
      {
        accessorKey: 'houseNumber',
        header: 'House Number',
        mantineEditTextInputProps: {
          type: 'text',
          required: true,
          error: validationErrors?.houseNumber
        },
      },
      {
        accessorKey: 'apartmentNumber',
        header: 'Apartment Number',
        mantineEditTextInputProps: {
          type: 'text',
          required: true,
          error: validationErrors?.apartmentNumber
        },
      },
      {
        accessorKey: 'postalCode',
        header: 'Postal Code',
        mantineEditTextInputProps: {
          type: 'text',
          required: true,
          error: validationErrors?.postalCode
        },
      },
      {
        accessorKey: 'city',
        header: 'City',
        mantineEditTextInputProps: {
          type: 'text',
          required: true,
          error: validationErrors?.city
        },
      },
      {
        accessorKey: 'phone',
        header: 'Phone',
        mantineEditTextInputProps: {
          type: 'text',
          required: true,
          error: validationErrors?.phone
        },
      },
      {
        accessorKey: 'age',
        header: 'Age',
        mantineEditTextInputProps: {
          type: 'text',
          required: true,
          error: validationErrors?.age
        },
      }
    ],
    [validationErrors],
  );

  //call CREATE hook
  const { mutateAsync: createUser, isPending: isCreatingUser } =
    useCreateUser();
  //call READ hook
  const {
    data: fetchedUsers = [],
    isError: isLoadingUsersError,
    isFetching: isFetchingUsers,
    isLoading: isLoadingUsers,
  } = useGetUsers();
  //call UPDATE hook
  const { mutateAsync: updateUser, isPending: isUpdatingUser } =
    useUpdateUser();
  //call DELETE hook
  const { mutateAsync: deleteUser, isPending: isDeletingUser } =
    useDeleteUser();

  //CREATE action
  const handleCreateUser: MRT_TableOptions<Person>['onCreatingRowSave'] = async ({
    values,
    exitCreatingMode,
  }) => {
    setValidationErrors({});
    await createUser(values);
    exitCreatingMode();
  };

  //UPDATE action
  const handleSaveUser: MRT_TableOptions<Person>['onEditingRowSave'] = async ({
    values,
    table,
  }) => {
    await updateUser(values);
    table.setEditingRow(null); //exit editing mode
  };

  //DELETE action
  const openDeleteConfirmModal = (row: MRT_Row<Person>) =>
    modals.openConfirmModal({
      title: 'Are you sure you want to delete this user?',
      children: (
        <Text>
          Are you sure you want to delete {row.original.firstName}{' '}
          {row.original.lastName}? This action cannot be undone.
        </Text>
      ),
      labels: { confirm: 'Delete', cancel: 'Cancel' },
      confirmProps: { color: 'red' },
      onConfirm: () => deleteUser(row.original.id),
    });



  const table = useMantineReactTable({
    columns,
    data:fetchedUsers,
    createDisplayMode: 'row', // ('modal', and 'custom' are also available)
    editDisplayMode: 'row', // ('modal', 'cell', 'table', and 'custom' are also available)
    enableEditing: true,
    getRowId: (row) => row.id,
    mantineToolbarAlertBannerProps: isLoadingUsersError
      ? {
          color: 'red',
          children: 'Error loading data',
        }
      : undefined,
    mantineTableContainerProps: {
      style: {
        minHeight: '500px',
      },
    },
    onCreatingRowCancel: () => setValidationErrors({}),
    onCreatingRowSave: handleCreateUser,
    onEditingRowCancel: () => setValidationErrors({}),
    onEditingRowSave: handleSaveUser,
    renderRowActions: ({ row, table }) => (
      <Flex gap="md">
        <Tooltip label="Edit">
          <ActionIcon onClick={() => table.setEditingRow(row)}>
            <IconEdit />
          </ActionIcon>
        </Tooltip>
        <Tooltip label="Delete">
          <ActionIcon color="red" onClick={() => openDeleteConfirmModal(row)}>
            <IconTrash />
          </ActionIcon>
        </Tooltip>
      </Flex>
    ),
    renderTopToolbarCustomActions: ({ table }) => (
      <Button
        onClick={() => {
          table.setCreatingRow(true); //simplest way to open the create row modal with no default values
          //or you can pass in a row object to set default values with the `createRow` helper function
          // table.setCreatingRow(
          //   createRow(table, {
          //     //optionally pass in default values for the new row, useful for nested data or other complex scenarios
          //   }),
          // );
        }}
      >
        Create New User
      </Button>
    ),
    state: {
      isLoading: isLoadingUsers,
      isSaving: isCreatingUser || isUpdatingUser || isDeletingUser,
      showAlertBanner: isLoadingUsersError,
      showProgressBars: isFetchingUsers,
    },
  });

  return <MantineReactTable table={table} />;
};

//CREATE hook (post new user to api)
function useCreateUser() {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: async (user: Person) => {

      const response= await fetch(
          'http://localhost:5276/api/users',
          {
            method: 'POST',
            body: JSON.stringify({
              firstName: user.firstName,
              lastName: user.lastName,
              streetName: user.streetName,
              houseNumber: user.houseNumber,
              apartmentNumber: user.apartmentNumber,
              postalCode: user.postalCode,
              city: user.city,
              phone: user.phone,
              age: user.age
            }),
            headers: {
              'Content-Type': 'application/json', // Limited support for custom headers in no-cors
            }
          }
      )

      //send api update request here
      await new Promise((resolve) => setTimeout(resolve, 1000)); //fake api call
      return Promise.resolve();
    },
    //client side optimistic update
    onMutate: (newUserInfo: Person) => {
      queryClient.setQueryData(
        ['users'],
        (prevUsers: any) =>
          [
            ...prevUsers,
            {
              ...newUserInfo,
              id: uuidv4(),
            },
          ] as Person[],
      );
    },
  });
}
//READ hook (get users from api)
function useGetUsers() {
  return useQuery<Person[]>({
    queryKey: ['users'],
    queryFn: async () => {
      const response= await fetch(
          'http://localhost:5276/api/users',
      )
      return response.json();
    },
    refetchOnWindowFocus: false,
  });
}

//UPDATE hook (put user in api)
function useUpdateUser() {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: async (user: Person) => {
      const response= await fetch(
          'http://localhost:5276/api/users/' + user.id,
          {
            method: 'PUT',
            headers: {
              'Content-Type': 'application/json'
            },
            body: JSON.stringify({
              firstName: user.firstName,
              lastName: user.lastName,
              streetName: user.streetName,
              houseNumber: user.houseNumber,
              apartmentNumber: user.apartmentNumber,
              postalCode: user.postalCode,
              city: user.city,
              phone: user.phone,
              age: user.age
            })
          });

      //send api update request here
      await new Promise((resolve) => setTimeout(resolve, 1000)); //fake api call
      return Promise.resolve();
    },
    //client side optimistic update
    onMutate: (newUserInfo: Person) => {
      queryClient.setQueryData(['users'], (prevUsers: any) =>
        prevUsers?.map((prevUser: Person) =>
          prevUser.id === newUserInfo.id ? newUserInfo : prevUser,
        ),
      );
    },
  });
}

//DELETE hook (delete user in api)
function useDeleteUser() {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: async (userId: string) => {
      const response= await fetch(
          'http://localhost:5276/api/users/' + userId,
          {
            method: 'DELETE',
            headers: {
              'Content-Type': 'application/json'
            }
          });
      await new Promise((resolve) => setTimeout(resolve, 1000)); //fake api call
      return Promise.resolve();
    },

    onMutate: (userId: string) => {
      queryClient.setQueryData(['users'], (prevUsers: any) =>
        prevUsers?.filter((user: Person) => user.id !== userId),
      );
    },
  });
}

const queryClient = new QueryClient();

const ExampleWithProviders = () => (
  //Put this with your other react-query providers near root of your app
  <QueryClientProvider client={queryClient}>
    <ModalsProvider>
      <Example />
    </ModalsProvider>
  </QueryClientProvider>
);

export default ExampleWithProviders;

