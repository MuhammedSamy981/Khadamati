export interface IRequestData{
    id: number,
    requestText:string ,
    date: Date,
    status: string,
    serviceDetails: {
        id: number,
        name: string
    },
    providerDetails: {
        providerName: string
        ProviderID:string
    },
    userDetails:{
    userName: string;
    userID: string;
    userPhone: string | null;
    }
}

